﻿using AutoMapper;
using BlazorApp.Application.Services.User;
using BlazorApp.Domain.Requests;
using BlazorApp.Domain.Responses;
using Microsoft.AspNetCore.Authorization;
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
        [ProducesResponseType(typeof(ApiResponse<List<UserResponse>>), StatusCodes.Status200OK)]
        public ApiResponse<List<UserResponse>> UserList()
        {
            return _userService.UserList();
        }

        [Authorize]
        [HttpGet("Get")]
        [ProducesResponseType(typeof(ApiResponse<UserResponse>), StatusCodes.Status200OK)]
        public ApiResponse<UserResponse> GetUser(long id)
        {
            return _userService.GetUser(id);
        }

        [Authorize]
        [HttpPost("Create")]
        [ProducesResponseType(typeof(ApiResponse<long>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<long>), StatusCodes.Status404NotFound)]
        public ApiResponse<long> Create([FromBody] UserRequest user)
        {
            var response = _userService.Create(user);
            return response;
        }
    }
}
