using Microsoft.AspNetCore.Mvc;

namespace Currency.Exchange.API.Base
{
    [ApiController, Route("api/[controller]")]
    public abstract class BaseController<T> : ControllerBase
    {
        private ILogger<T> _loggerInstance;

        protected ILogger<T> _logger => _loggerInstance ??= HttpContext.RequestServices.GetService<ILogger<T>>();

    }
}
