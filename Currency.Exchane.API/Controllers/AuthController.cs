using Currency.Exchange.API.Base;
using Currency.Exchange.Public.Dtos.Auth;
using Currency.Exchange.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Currency.Exchange.API.Controllers
{
    public class AuthController : BaseController<AuthController>
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        /// <summary>
        /// Adds new user
        /// </summary>
        /// <param name="Auth"></param>
        /// <returns></returns>
        [HttpPost("add-user")]
        public async Task<IActionResult> Add(UserInsertRequest request)
        {
            var createResult = await _authService.AddUser(request);
            return Ok(createResult);
        }

        /// <summary>
        /// Login new user
        /// </summary>
        /// <param name="Auth"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var createResult = await _authService.Login(request);
            return Ok(createResult);
        }

        /// <summary>
        /// Get User Info
        /// </summary>
        /// <param name="Auth"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("get-user-info")]
        public async Task<IActionResult> GetUserInfo()
        {
            var createResult = await _authService.GetUserInfo();
            return Ok(createResult);
        }

    }
}
