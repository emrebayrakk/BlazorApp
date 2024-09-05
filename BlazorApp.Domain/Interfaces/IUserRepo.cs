using BlazorApp.Domain.Entities;
using BlazorApp.Domain.Requests;
using BlazorApp.Domain.Responses;

namespace BlazorApp.Domain.Interfaces
{
    public interface IUserRepo : IGenericRepo<User, UserRequest, UserResponse>
    {
    }
}
