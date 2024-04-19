using RentMotorcycle.Application.Base;
using RentMotorcycle.Domain.ProfileAggregate;
using RentMotorcycle.Domain.UserAggregate;

namespace RentMotorcycle.Application.Users
{
    public class UserResult : BaseEntityResult
    {
        public UserResult(
            bool success = true, 
            string? message = null,
            User? user = null) : base(success, message)
        {
        }

        public User? User { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Profile Perfil { get; set; }
    }
}
