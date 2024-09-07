using BlazorApp.Domain.Entities;
using BlazorApp.Domain.Responses;

namespace BlazorApp.Domain.Interfaces
{
    public interface IJwtProvider
    {
        UserLoginResponse CreateToken(User user);
    }
}
