namespace BlazorApp.Domain.Responses
{
    public class UserLoginResponse
    {
        public string Token { get; set; } = string.Empty;
        public DateTime TokenExpired { get; set; }
    }
}
