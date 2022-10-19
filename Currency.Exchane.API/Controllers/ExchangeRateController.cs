using Currency.Exchange.API.Base;
using Currency.Exchange.Public.ExchangeRate;
using Currency.Exchange.Services.ExchangeRate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Currency.Exchange.API.Controllers
{
    [Authorize]
    public class ExchangeRateController : BaseController<AuthController>
    {
        private readonly IExchangeRateService _exchangeRateService;

        public ExchangeRateController(IExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
        }

        /// <summary>
        /// Get ExchangeRates
        /// </summary>
        /// <param name="ExchangeRateRequest"></param>
        /// <returns>BaseResponse<ExchangeRateResponse></returns>
        [HttpPost("get-rates")]
        public async Task<IActionResult> GetRates(ExchangeRateRequest request)
        {
            var createResult = await _exchangeRateService.GetRates(request);
            return Ok(createResult);
        }
    }
}
