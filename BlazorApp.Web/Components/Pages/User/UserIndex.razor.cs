using BlazorApp.Domain.Responses;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace BlazorApp.Web.Components.Pages.User
{
    public partial class UserIndex
    {
        [Inject]
        public ApiClient ApiClient { get; set; }
        public List<UserResponse> UserResponses {  get; set; }
        protected override async Task OnInitializedAsync()
        {
            var res = await ApiClient.GetFromJsonAsync<ApiResponse<List<UserResponse>>>("/api/User/List");
            if (res != null && res.Data != null)
            {
                UserResponses = res.Data;
            }
            await base.OnInitializedAsync();
        }
    }
}
