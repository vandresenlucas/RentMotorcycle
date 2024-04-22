using RentMotorcycle.Application.Base;
using RentMotorcycle.Data.DeliveryManAggregate;

namespace RentMotorcycle.Application.Users
{
    public class UserResult : BaseResult
    {
        public object? Deliveryman;

        public UserResult(
            bool success = true,
            string? message = null) : base(success, message)
        {
        }

        public UserResult(
            object? deliveryman = null, 
            bool success = true, 
            string? message = null,
            object? result = null) : base(success, message, result)
        {
            Deliveryman = deliveryman;
        }
    }
}
