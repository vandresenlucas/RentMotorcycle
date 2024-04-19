using MediatR;
using RentMotorcycle.Domain.ProfileAggregate;
using RentMotorcycle.Domain.UserAggregate;

namespace RentMotorcycle.Application.Users
{
    public class UserCommandHandler : IRequestHandler<AddUserCommand, UserResult>
    {
        private readonly IUserRepository _userRepository;

        public UserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResult> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            User user = request;

            var newUser = await _userRepository.AddAsync(user);

            
            return new UserResult(user: newUser);
        }
    }
}
