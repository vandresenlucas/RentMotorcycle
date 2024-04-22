namespace RentMotorcycle.Application.Base
{
    public class BaseResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public object? Result { get; set; }

        public BaseResult(  
            bool success = true,
            string? message = null)
        {
            Success = success;
            Message = message;
        }

        public BaseResult(bool success = true, string? message = null, object? result = null)
        {
            Success = success;
            Message = message;
            Result = result;
        }
    }
}
