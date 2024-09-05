namespace BlazorApp.Domain.Responses
{
    public class ApiResponse<T>
    {
        public int Code { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public ApiResponse(
            bool status,
            int code,
            string message,
            T data)
        {
            Code = code;
            Status = status;
            Message = message;
            Data = data;
        }
    }
}
