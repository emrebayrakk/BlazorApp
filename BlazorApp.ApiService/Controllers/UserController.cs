using AutoMapper;
using BlazorApp.Application.Services.User;
using BlazorApp.Domain.Entities;
using BlazorApp.Domain.Requests;
using BlazorApp.Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.ApiService.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        #region Constructors

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }


        #endregion

        [HttpGet("List")]
        public async Task<ApiResponse<List<UserResponse>>> UserList()
        {
            return await _userService.UserList();
        }

        [HttpGet("{id}")]
        public async Task<ApiResponse<UserResponse>> GetUser(long id)
        {
            return await _userService.GetUser(id);
        }

        [HttpDelete("{id}")]
        public async Task<ApiResponse<long>> DeleteUser(long id)
        {
            return await _userService.DeleteUser(id);
        }

        [HttpPost("Create")]
        public async Task<ApiResponse<long>> Create([FromBody] UserRequest user)
        {
            var response = await _userService.Create(user);
            return response;
        }
        [HttpPut("Update")]
        public async Task<ApiResponse<long>> Update([FromBody] User user)
        {
            var response = await _userService.Update(user);
            return response;
        }
    }
}
