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
                return new MotorcycleResult() 
                { 
                    IdentifyCode = request.IdentifyCode,
                    Year = request.Year,
                    Model = request.Model,
                    LicensePlate = request.LicensePlate
                };

            var newMotorcycle = await _motorcycleRepository.AddAsync(motorCycle);

            return new MotorcycleResult()
            {
                IdentifyCode = newMotorcycle.IdentifyCode,
                Year = newMotorcycle.Year,
                Model = newMotorcycle.Model,
                LicensePlate = newMotorcycle.LicensePlate
            };
        }
    }
}
