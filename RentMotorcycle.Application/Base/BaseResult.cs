namespace RentMotorcycle.Application.Base
{
    public class BaseResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }

        public BaseResult(
            bool success,
            string? message = null)
        {
            Success = success;
            Message = message;
        }
    }
}
