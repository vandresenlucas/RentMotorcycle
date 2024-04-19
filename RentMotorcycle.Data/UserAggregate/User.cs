using RentMotorcycle.Data.Base;
using RentMotorcycle.Domain.ProfileAggregate;

namespace RentMotorcycle.Domain.UserAggregate
{
    public class User : EntityBase
    {
        public User(
            string name, 
            string email, 
            string password, 
            Perfil perfil,
            DateTime createdDate)
        {
            Name = name;
            Email = email;
            Password = password;
            Perfil = perfil;
            CreatedDate = createdDate;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Perfil Perfil { get; set; }

    }
}