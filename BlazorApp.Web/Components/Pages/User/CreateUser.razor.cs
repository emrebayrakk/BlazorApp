﻿using BlazorApp.Domain.Requests;
using BlazorApp.Domain.Responses;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Web.Components.Pages.User
{
    public partial class CreateUser
    {
        [Inject]
        public ApiClient ApiClient { get; set; }
        public UserRequest UserRequest { get; set; } = new();
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        [Inject] protected ToastService ToastService { get; set; } = default!;
        public async Task Submit()
        {
            var res = await ApiClient.PostAsync<ApiResponse<long>, UserRequest>("/api/User/Create", UserRequest);
            if (res.Data == 0 || res.Data == -1)
            {
                //toastr
                var message = new ToastMessage
                {
                    Type = ToastType.Danger,
                    Title = "Error!",
                    HelpText = $"{DateTime.Now}",
                    Message = "Not Created User!",
                };
                ToastService.Notify(message);
            }
            else
            {
                //toastr
                var message = new ToastMessage
                {
                    Type = ToastType.Success,
                    Title = "Succesfull!",
                    HelpText = $"{DateTime.Now}",
                    Message = "Created User!",
                };
                ToastService.Notify(message);
                NavigationManager.NavigateTo("/usr");
            }
        }
    }
}
