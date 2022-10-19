using Currency.Exchange.Shared.ServiceDependencies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Currency.Exchange.Public.BaseResultModels;
using Currency.Exchange.Public.Dtos.Auth;

namespace Currency.Exchange.Services.Auth
{
    public class AuthService : IAuthService, IScopedService
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<BaseResponse<UserDto>> AddUser(UserInsertRequest request)
        {
            IdentityUser user = new IdentityUser()
            {
                UserName = request.UserName.Trim(),
                Email = request.Email.Trim()
            };
            IdentityResult result = await _userManager.CreateAsync(user, request.Password.Trim());
            if (result.Succeeded)
            {
                if (!_roleManager.RoleExistsAsync("User").Result)
                {
                    IdentityRole role = new IdentityRole()
                    {
                        Name = "User"
                    };
                    IdentityResult roleResult = await _roleManager.CreateAsync(role);
                    if (roleResult.Succeeded)
                    {
                        _userManager.AddToRoleAsync(user, "User").Wait();
                    }
                }
                _userManager.AddToRoleAsync(user, "User").Wait();
                return new BaseResponse<UserDto>()
                {
                    Data = new UserDto()
                    {
                        Email = user.Email,

                    }
                };
            }
            else
            {
                return new BaseResponse<UserDto>
                {
                    HasError = true,
                    ErrorMessage = "User can not be created"
                };
            }
        }

        public Task<UserDto> GetUserInfo()
        {
            var b = _httpContextAccessor.HttpContext.User.Identity;
            var identity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                return Task.FromResult(new UserDto()
                {
                    Email = identity?.Claims?.FirstOrDefault(x => x.Type == "mail")?.Value,
                    Id = identity?.Claims?.FirstOrDefault(x => x.Type == "userid")?.Value,
                    UserName = identity?.Claims?.FirstOrDefault(x => x.Type == "username")?.Value,
                });
            }
            return null;
        }

        public async Task<BaseResponse<LoginResponse>> Login(LoginRequest request)
        {
            IdentityUser user = await _userManager.FindByNameAsync(request.UserName.Trim());
            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password.Trim()))
            {
                var claims = new[]
                {
                        new Claim("username",user.UserName),
                        new Claim("userid",user.Id),
                        new Claim("mail",user.Email),
                    };

                var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecureKey"));

                var token = new JwtSecurityToken(
                    issuer: "Evren",
                    audience: "Evren",
                    expires: DateTime.UtcNow.AddHours(1),
                    claims: claims,
                    signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                    );

                return new BaseResponse<LoginResponse>()
                {
                    Data = new LoginResponse()
                    {
                        JwtToken = new JwtSecurityTokenHandler().WriteToken(token),

                    }
                };
            }
            else
            {
                return new BaseResponse<LoginResponse>
                {
                    HasError = true,
                    ErrorMessage = "User could not be found"
                };
            }
        }
    }
}
