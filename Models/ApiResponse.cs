namespace CobranzasApi.Models
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        public T? Data { get; set; }

        public ApiResponse(T? data, bool success = true, string? errorMessage = null)
        {
            Data = data;
            Success = success;
            ErrorMessage = errorMessage;
        }

        public static ApiResponse<T> CreateError(string errorMessage)
        {
            return new ApiResponse<T>(default, false, errorMessage);
        }

    }
}
