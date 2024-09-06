using BlazorApp.Domain.Entities;
using BlazorApp.Domain.Responses;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Web.Components.Pages.User
{
    public partial class UpdateUser : ComponentBase
    {
        [Parameter]
        public long Id { get; set; }

        public UserResponse UserResponse { get; set; } = new();

        [Inject]
        public ApiClient ApiClient { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }
        [Inject] protected ToastService ToastService { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            var res = await ApiClient.GetFromJsonAsync<ApiResponse<UserResponse>>($"/api/User/{Id}");
            if (res.Data != null)
            {
                UserResponse = res.Data;
            }
        }
        public async Task Submit()
        {
            var req = new BlazorApp.Domain.Entities.User
            {
                Id = UserResponse.Id,
                FirstName = UserResponse.FirstName,
                LastName = UserResponse.LastName,
                Email = UserResponse.Email,
                Password = UserResponse.Password,
            };
            var res = await ApiClient.PutAsync<ApiResponse<long>, BlazorApp.Domain.Entities.User>("/api/User/Update", req);
            if (res.Data == 0 || res.Data == -1)
            {
                //toastr
                var message = new ToastMessage
                {
                    Type = ToastType.Danger,
                    Title = "Error!",
                    HelpText = $"{DateTime.Now}",
                    Message = "Not Updated User!",
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
                    Message = "Updated User!",
                };
                ToastService.Notify(message);
                NavigationManager.NavigateTo("/usr");
            }
        }
    }
}
