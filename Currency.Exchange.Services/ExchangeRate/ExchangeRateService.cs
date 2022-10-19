using Currency.Exchange.Core.DbEntities;
using Currency.Exchange.EntityFramework.UnitOfWork;
using Currency.Exchange.Public.BaseResultModels;
using Currency.Exchange.Public.ExchangeRate;
using Currency.Exchange.Services.Auth;
using Currency.Exchange.Services.ExchangeRateData;
using Currency.Exchange.Services.Validation;
using Currency.Exchange.Shared.ServiceDependencies;

namespace Currency.Exchange.Services.ExchangeRate
{
    public class ExchangeRateService : IExchangeRateService, IScopedService
    {
        private readonly IExchangeRateDataService _exchangeRateDataService;
        private readonly IAuthService _authService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        public ExchangeRateService(IExchangeRateDataService exchangeRateDataService, IAuthService authService, IUnitOfWork unitOfWork, IValidationService validationService)
        {
            _exchangeRateDataService = exchangeRateDataService;
            _authService = authService;
            _unitOfWork = unitOfWork;
            _validationService = validationService;
        }

        public async Task<BaseResponse<ExchangeRateResponse>> GetRates(ExchangeRateRequest request)
        {
            var userInfo = await _authService.GetUserInfo();
            if (userInfo == null) return new BaseResponse<ExchangeRateResponse>()
            {
                ErrorMessage = "User information could not be found, please log in.",
                HasError = true
            };
            var isValidTransaction = await _validationService.IsValidTransaction(userInfo.Id);
            if (!isValidTransaction.Data) return new BaseResponse<ExchangeRateResponse>()
            {
                ErrorMessage = "You reached transaction limit per hour",
                HasError = true
            };
            var rates = await _exchangeRateDataService.GetRates(new Public.ExchangeRateData.ExchangeRateDataRequest()
            {
                FromCurrency = request.FromCurrency,
            });


            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(rates.Data.timestamp).ToLocalTime();
            Console.WriteLine(dt);

            await _unitOfWork.GetRepository<ExchangeRateEntity>().AddAsync(new ExchangeRateEntity()
            {
                CreatedBy = userInfo.Id,
                FromCurrency = request.FromCurrency,
                CreatedOn = DateTime.Now,
                ToCurrency = "USD"
            });
            await _unitOfWork.SaveChangesAsync();

            var response = new BaseResponse<ExchangeRateResponse>()
            {
                Data = new ExchangeRateResponse()
                {
                    FromCurrency = request.FromCurrency,
                    DateOfCurrency = dt,
                    ExchangeRates = rates?.Data?.rates?.Select(x => new Public.ExchangeRate.ExchangeRate()
                    {
                        ToCurrency = x.Key,
                        Value = x.Value
                    }).ToList(),
                }
            };

            if(!string.IsNullOrEmpty(request.ToCurrencies))
            {
                var wantedCurrencies=request.ToCurrencies.Split(",").ToList();
                response.Data.ExchangeRates = response?.Data?.ExchangeRates?.Where(x => wantedCurrencies.Contains(x.ToCurrency))?.ToList();
            }
            return response;
        }
    }
}
