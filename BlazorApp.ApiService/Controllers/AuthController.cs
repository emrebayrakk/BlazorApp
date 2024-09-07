using BlazorApp.Application.Services.Auth;
using BlazorApp.Domain.Requests;
using BlazorApp.Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.ApiService.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<ApiResponse<UserLoginResponse>> Login([FromBody] UserLoginRequest req)
        {
            var response = await _authService.Login(req);
            return response;
        }
    }
}
