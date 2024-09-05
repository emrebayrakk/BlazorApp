using AutoMapper;
using BlazorApp.Data.Context;
using BlazorApp.Domain.Entities;
using BlazorApp.Domain.Interfaces;
using BlazorApp.Domain.Requests;
using BlazorApp.Domain.Responses;

namespace BlazorApp.Data.Repositories
{
    public class UserRepo : GenericRepo<User, UserRequest, UserResponse>, IUserRepo
    {
        public UserRepo(BlazorAppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
