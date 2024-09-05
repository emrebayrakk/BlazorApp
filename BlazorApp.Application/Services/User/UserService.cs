using BlazorApp.Domain.Interfaces;
using BlazorApp.Domain.Requests;
using BlazorApp.Domain.Responses;

namespace BlazorApp.Application.Services.User
{
    public class UserService : IUserService
    {
        public IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<ApiResponse<long>> Create(UserRequest userInput)
        {
            long id = await _userRepo.Add(userInput);
            if (id != -1)
                return new ApiResponse<long>(true, ResultCode.Instance.Ok, "Success", id);
            return new ApiResponse<long>(false, ResultCode.Instance.Failed, "ErrorOccured", -1);
        }

        public async Task<ApiResponse<UserResponse>> GetUser(long id)
        {
            var result = await _userRepo.FirstOrDefaultAsync(x => x.Id == id);
            return new ApiResponse<UserResponse>(true, ResultCode.Instance.Ok, "Success", result);
        }

        public async Task<ApiResponse<string>> Login(UserLoginRequest login)
        {
            var result = await _userRepo.FirstOrDefault(a => a.Email == login.Email && a.Password == login.Password);
            if (result is not null)
            {
                return new ApiResponse<string>(true, ResultCode.Instance.Ok, "Success", "token");
            }
            return new ApiResponse<string>(false, ResultCode.Instance.LoginInvalid, "LoginInvalid", "");

        }

        public async Task<ApiResponse<List<UserResponse>>> UserList()
        {
            var result = await _userRepo.GetAll();
            return new ApiResponse<List<UserResponse>>(true, ResultCode.Instance.Ok, "Success", result);
        }
    }
}
