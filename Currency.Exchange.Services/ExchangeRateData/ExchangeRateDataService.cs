using AutoMapper;
using Currency.Exchange.Core.DbEntities;
using Currency.Exchange.EntityFramework.Redis;
using Currency.Exchange.EntityFramework.UnitOfWork;
using Currency.Exchange.Public.BaseResultModels;
using Currency.Exchange.Public.ExchangeRateData;
using Currency.Exchange.Services.Log;
using Currency.Exchange.Shared.CacheKey;
using Currency.Exchange.Shared.ServiceDependencies;
using Currency.Exchange.Shared.Static;
using RestSharp;
using System.Diagnostics;

namespace Currency.Exchange.Services.ExchangeRateData
{
    public class ExchangeRateDataService : IExchangeRateDataService, IScopedService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRedisDatabaseProvider _redisDatabaseProvider;
        private readonly ILogService _logService;

        public ExchangeRateDataService(IUnitOfWork unitOfWork, IRedisDatabaseProvider redisDatabaseProvider, ILogService logService)
        {
            _unitOfWork = unitOfWork;
            _redisDatabaseProvider = redisDatabaseProvider;
            _logService = logService;
        }

        public async Task<BaseResponse<ExchangeRateDataResponse>> GetRates(ExchangeRateDataRequest request)
        {
            var response=new BaseResponse<ExchangeRateDataResponse>();
            var redisResponse = await _redisDatabaseProvider.GetAsync($"{CacheKeys.ExchangeRates}:{request.FromCurrency}");

            if (!string.IsNullOrEmpty(redisResponse))
            {
                response.Data = Newtonsoft.Json.JsonConvert.DeserializeObject<ExchangeRateDataResponse>(redisResponse);
                return response;
            }
            var toCurrencies = await _unitOfWork.GetRepository<CurrencyEntity>().GetAllAsync();
            var toCurrencyCodes = string.Join(',', toCurrencies.Select(x => x.Code));

            var client = new RestClient(StaticValues.ExchangeRateData_ServiceUrl);
            var serviceRequest = new RestRequest($"{StaticValues.ExchangeRateData_ServiceUrl}latest?symbols={toCurrencyCodes}&base={request.FromCurrency}", Method.Get);
            serviceRequest.AddHeader("apikey", StaticValues.ExchangeRateData_ApiKey);
            try
            {
                Stopwatch watch = Stopwatch.StartNew();
                RestResponse restResponse = await client.ExecuteAsync(serviceRequest);
                watch.Stop();
                if (restResponse.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception(restResponse.StatusCode.ToString());

                var serviceResponse = restResponse.Content;

                if (string.IsNullOrEmpty(serviceResponse)) throw new Exception("Could not get Exchange Rates from service");

                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ExchangeRateDataResponse>(serviceResponse);

                //write to redis

                await _redisDatabaseProvider.SetWithMinuteAsync($"{CacheKeys.ExchangeRates}:{request.FromCurrency}", serviceResponse, 30);

                response.Data = result;

                await _logService.WriteLog($"{StaticValues.ExchangeRateData_ServiceUrl}latest?symbols={toCurrencyCodes}&base={request.FromCurrency}",
                    serviceResponse, "", "ExchangeRateDataService", "latest", watch.ElapsedMilliseconds, "", false);
            }
            catch (Exception ex)
            {

                throw;
            }
            
            return response;
        }
    }
}
