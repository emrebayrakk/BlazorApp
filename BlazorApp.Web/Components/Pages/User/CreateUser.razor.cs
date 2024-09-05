using BlazorApp.Domain.Requests;
using BlazorApp.Domain.Responses;
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
        public async Task Submit()
        {
            var res = await ApiClient.PostAsync<ApiResponse<long>, UserRequest>("/api/User/Create", UserRequest);
            if (res.Data == 0 || res.Data == -1)
            {
                //toastr
            }
            else
            {
                //toastr
                NavigationManager.NavigateTo("/users");
            }
        }
    }
}
