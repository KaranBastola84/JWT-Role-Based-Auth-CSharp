namespace JWTAuthAPI.Models
{
    public class ApiResponse<T>
    {
        public T? Result { get; set; }
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ApiResponse(T? result, bool isSuccess, int statusCode, string message)
        {
            Result = result;
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message;
        }
    }
}