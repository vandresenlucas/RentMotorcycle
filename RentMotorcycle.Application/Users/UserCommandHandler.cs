using MediatR;
using RentMotorcycle.Application.Deliverymans.Services;
using RentMotorcycle.Domain.ProfileAggregate;
using RentMotorcycle.Domain.UserAggregate;

namespace RentMotorcycle.Application.Users
{
    public class UserCommandHandler : IRequestHandler<AddUserCommand, UserResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;
        private readonly IDeliverymanService _deliverymanService;

        public UserCommandHandler(IUserRepository userRepository, IMediator mediator, IDeliverymanService deliverymanService)
        {
            _userRepository = userRepository;
            _mediator = mediator;
            _deliverymanService = deliverymanService;
        }

        public async Task<UserResult> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            User user = request;

            var userFound = await _userRepository.GetByEmail(user.Email);

            if (userFound != null)
                return new UserResult(
                    false,
                    message: string.Format($"O usuário com Email '{user.Email}', já está cadastrado no sistema!!"));

            var deliverymanduplicated = 
                await _deliverymanService.VerifyDuplicatedDeliveryman(
                    request.DeliveryMan.Cnpj, 
                    request.DeliveryMan.LicenseDriverNumber);

            if (!deliverymanduplicated.Success)
                return new UserResult(deliveryResult: deliverymanduplicated);

            var newUser = await _userRepository.AddAsync(user);

            if (user.Profile == Profile.Deliveryman) 
            {
                request.DeliveryMan.UserId = newUser.Id;
                var newDeliveryMan = await _mediator.Send(request.DeliveryMan);

                return new UserResult(user: newUser, deliveryResult: newDeliveryMan);
            }
            
            return new UserResult(user: newUser);
        }
    }
}
