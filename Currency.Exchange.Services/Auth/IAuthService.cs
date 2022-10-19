using Currency.Exchange.Public.BaseResultModels;
using Currency.Exchange.Public.Dtos.Auth;

namespace Currency.Exchange.Services.Auth
{
    public interface IAuthService
    {
        public Task<BaseResponse<UserDto>> AddUser(UserInsertRequest request);
        public Task<BaseResponse<LoginResponse>> Login(LoginRequest request);
        public Task<UserDto> GetUserInfo();
    }
}
