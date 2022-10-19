using Currency.Exchange.Public.BaseResultModels;
using Currency.Exchange.Public.ExchangeRateData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Exchange.Services.ExchangeRateData
{
    public interface IExchangeRateDataService
    {
        public Task<BaseResponse<ExchangeRateDataResponse>> GetRates(ExchangeRateDataRequest request);
    }
}
