using BlazorApp.Domain.Requests;
using BlazorApp.Domain.Responses;

namespace BlazorApp.Application.Services.Auth
{
    public interface IAuthService
    {
        Task<ApiResponse<UserLoginResponse>> Login(UserLoginRequest login);
    }
}
