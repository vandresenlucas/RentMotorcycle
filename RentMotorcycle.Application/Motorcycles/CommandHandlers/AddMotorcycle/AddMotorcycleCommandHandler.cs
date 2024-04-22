using MediatR;
using RentMotorcycle.Application.Base;
using RentMotorcycle.Data.MotorcycleAggregate;

namespace RentMotorcycle.Application.Motorcycles.CommandHandlers.AddMotorcycle
{
    public class AddMotorcycleCommandHandler : IRequestHandler<AddMotorcycleCommand, BaseResult>
    {
        private readonly IMotorcycleRepository _motorcycleRepository;

        public AddMotorcycleCommandHandler(IMotorcycleRepository motorcycleRepository)
        {
            _motorcycleRepository = motorcycleRepository;
        }

        public async Task<BaseResult> Handle(AddMotorcycleCommand request, CancellationToken cancellationToken)
        {
            Motorcycle motorCycle = request;

            var motorcycleFound = await _motorcycleRepository.GetByLicensePlate(request.LicensePlate);

            if (motorcycleFound != null)
                return new BaseResult(
                    false,
                    message: string.Format($"A moto com placa '{motorCycle.LicensePlate}', já está cadastrada no sistema!!"));

            var newMotorcycle = await _motorcycleRepository.AddAsync(motorCycle);

            return new BaseResult(result: newMotorcycle);
        }
    }
}
