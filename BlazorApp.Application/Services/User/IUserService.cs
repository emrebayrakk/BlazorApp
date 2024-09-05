using BlazorApp.Domain.Requests;
using BlazorApp.Domain.Responses;

namespace BlazorApp.Application.Services.User
{
    public interface IUserService
    {
        Task<ApiResponse<long>> Create(UserRequest userInput);
        Task<ApiResponse<List<UserResponse>>> UserList();
        Task<ApiResponse<UserResponse>> GetUser(long id);
        Task<ApiResponse<string>> Login(UserLoginRequest login);
    }
}
