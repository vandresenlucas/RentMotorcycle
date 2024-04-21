using MediatR;
using RentMotorcycle.Application.Deliverymans;
using RentMotorcycle.Data.ProfileAggregate;
using RentMotorcycle.Data.UserAggregate;

namespace RentMotorcycle.Application.Users
{
    public class AddUserCommand : IRequest<UserResult>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Profile Profile { get; set; }
        public AddDeliverymanCommand? DeliveryMan { get; set; }

        public static implicit operator User(AddUserCommand command)
        {
            if (command == null)
                return null;

            return new(
                command.Name,
                command.Email,
                command.Password,
                command.Profile,
                DateTime.UtcNow);
        }
    }
}