using BlazorApp.Domain.Interfaces;
using BlazorApp.Domain.Requests;
using BlazorApp.Domain.Responses;

namespace BlazorApp.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepo _userRepo;
        private readonly IJwtProvider _jwtProvider;
        public AuthService(IUserRepo userRepo, IJwtProvider jwtProvider)
        {
            _userRepo = userRepo;
            _jwtProvider = jwtProvider;
        }

        public async Task<ApiResponse<UserLoginResponse>> Login(UserLoginRequest login)
        {
            var result = await _userRepo.FirstOrDefault(a => a.Email == login.Email && a.Password == login.Password);
            if (result is not null)
            {
                var token = _jwtProvider.CreateToken(result);
                return new ApiResponse<UserLoginResponse>(true, ResultCode.Instance.Ok, "Success", token);
            }
            return new ApiResponse<UserLoginResponse>(false, ResultCode.Instance.LoginInvalid, "LoginInvalid", null);
        }
    }
}
