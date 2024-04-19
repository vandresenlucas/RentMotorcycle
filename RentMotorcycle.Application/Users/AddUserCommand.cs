using MediatR;
using RentMotorcycle.Domain.ProfileAggregate;
using RentMotorcycle.Domain.UserAggregate;

namespace RentMotorcycle.Application.Users
{
    public class AddUserCommand : IRequest<UserResult>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Perfil Perfil { get; set; }

        public static implicit operator User(AddUserCommand command)
        {
            if (command == null)
                return null;

            return new(
                command.Name,
                command.Email,
                command.Password,
                Perfil.Deliveryman,
                DateTime.UtcNow);
        }
    }
}