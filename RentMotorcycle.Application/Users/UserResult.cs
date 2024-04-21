using RentMotorcycle.Application.Base;
using RentMotorcycle.Application.Deliverymans;
using RentMotorcycle.Data.ProfileAggregate;
using RentMotorcycle.Data.UserAggregate;

namespace RentMotorcycle.Application.Users
{
    public class UserResult : BaseEntityResult
    {
        public UserResult(
            bool success = true, 
            string? message = null,
            User? user = null,
            DeliverymanResult? deliveryResult = null) : base(success, message)
        {
            User = user;
            DeliveryResult = deliveryResult;
        }

        public User? User { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Profile Perfil { get; set; }
        public DeliverymanResult? DeliveryResult { get; set; }
    }
}
