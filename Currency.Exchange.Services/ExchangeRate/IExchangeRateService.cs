using Currency.Exchange.Public.BaseResultModels;
using Currency.Exchange.Public.ExchangeRate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Exchange.Services.ExchangeRate
{
    public interface IExchangeRateService
    {
        public Task<BaseResponse<ExchangeRateResponse>> GetRates(ExchangeRateRequest request);
    }
}
