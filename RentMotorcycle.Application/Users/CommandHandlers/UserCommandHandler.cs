using MediatR;
using RentMotorcycle.Application.Deliverymans.Services;
using RentMotorcycle.Application.Users.Results;
using RentMotorcycle.Data.ProfileAggregate;
using RentMotorcycle.Data.UserAggregate;

namespace RentMotorcycle.Application.Users.CommandHandlers
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
                return new UserResult(result: deliverymanduplicated);

            var newUser = await _userRepository.AddAsync(user);

            if (user.Profile == Profile.Deliveryman)
            {
                request.DeliveryMan.UserId = newUser.Id;
                var newDeliveryMan = await _mediator.Send(request.DeliveryMan);

                return new UserResult(result: newUser, deliveryman: newDeliveryMan.Result);
            }

            return new UserResult(result: newUser);
        }
    }
}
