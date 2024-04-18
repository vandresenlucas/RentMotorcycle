using RentMotorcycle.Domain.ProfileAggregate;

namespace RentMotorcycle.Domain.UserAggregate
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Perfil Perfil { get; set; }
    }
}