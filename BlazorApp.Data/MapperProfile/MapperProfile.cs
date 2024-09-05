using AutoMapper;
using BlazorApp.Domain.Entities;
using BlazorApp.Domain.Requests;
using BlazorApp.Domain.Responses;

namespace BlazorApp.Data.MapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserRequest, User>();
            CreateMap<User, UserRequest>();

            CreateMap<UserResponse, User>();
            CreateMap<User, UserResponse>();
        }
    }
}
