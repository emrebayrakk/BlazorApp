using BlazorApp.Domain.Responses;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Web.Components.Pages.User
{
    public partial class UserIndex
    {
        [Inject]
        public ApiClient ApiClient { get; set; }
        public IEnumerable<UserResponse> UserResponses {  get; set; }
        private Modal modal { get; set; }
        public int DeletedId { get; set; }
        [Inject] protected ToastService ToastService { get; set; } = default!;
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await LoadUsers();
        }
        protected async Task LoadUsers()
        {
            var res = await ApiClient.GetFromJsonAsync<ApiResponse<List<UserResponse>>>("/api/User/List");
            if (res != null && res.Data != null)
            {
                UserResponses = res.Data;
            }
        }
        private async Task<GridDataProviderResult<UserResponse>> EmployeesDataProvider(GridDataProviderRequest<UserResponse> request)
        {
            return await Task.FromResult(request.ApplyTo(UserResponses));
        }
        private async Task OnShowModalClick()
        {
            await modal?.ShowAsync();
        }

        private async Task OnHideModalClick()
        {
            await modal?.HideAsync();
        }
        protected async Task HandleDelete()
        {
            var res = await ApiClient.DeleteAsync<ApiResponse<long>>($"/api/User/{DeletedId}");
            if (res.Data == 0 || res.Data == -1)
            {
                //toastr
                var message = new ToastMessage
                {
                    Type = ToastType.Danger,
                    Title = "Error!",
                    HelpText = $"{DateTime.Now}",
                    Message = "Not Deleted User!",
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
                    Message = "Deleted User!",
                };
                ToastService.Notify(message);
                await LoadUsers();
                await modal?.HideAsync();
            }
        }

    }
}
