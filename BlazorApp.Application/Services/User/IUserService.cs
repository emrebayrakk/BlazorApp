using BlazorApp.Domain.Requests;
using BlazorApp.Domain.Responses;

namespace BlazorApp.Application.Services.User
{
    public interface IUserService
    {
        ApiResponse<long> Create(UserRequest userInput);
        ApiResponse<List<UserResponse>> UserList();
        ApiResponse<UserResponse> GetUser(long id);
        ApiResponse<string> Login(UserLoginRequest login);
    }
}
