namespace RentMotorcycle.Application.Base
{
    public class BaseResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public Dictionary<string, string[]>? ErrorMessages { get; set; }

        public BaseResult(
            bool success,
            string? message = null,
            Dictionary<string, string[]>? errorMessages = null)
        {
            Success = success;
            Message = message;
            ErrorMessages = errorMessages;
        }
    }
}
