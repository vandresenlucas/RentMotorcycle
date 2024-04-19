using MediatR;
using RentMotorcycle.Data.MotorcycleAggregate;

namespace RentMotorcycle.Application.Motorcycles
{
    public class MotorcycleCommandHandler : IRequestHandler<AddMotorcycleCommand, MotorcycleResult>
    {
        private readonly IMotorcycleRepository _motorcycleRepository;

        public MotorcycleCommandHandler(IMotorcycleRepository motorcycleRepository)
        {
            _motorcycleRepository = motorcycleRepository;
        }

        public async Task<MotorcycleResult> Handle(AddMotorcycleCommand request, CancellationToken cancellationToken)
        {
            Motorcycle motorCycle = request;

            var motorcycleFound = await _motorcycleRepository.GetByLicensePlate(request.LicensePlate);

            if (motorcycleFound != null)
                return new MotorcycleResult(
                    false, 
                    message: string.Format($"A moto com placa '{motorCycle.LicensePlate}', já está cadastrada no sistema!"));

            var newMotorcycle = await _motorcycleRepository.AddAsync(motorCycle);

            return new MotorcycleResult(motorcycle: newMotorcycle);
        }
    }
}
