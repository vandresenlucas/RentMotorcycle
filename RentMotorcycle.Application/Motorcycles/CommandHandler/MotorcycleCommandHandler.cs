using MediatR;
using RentMotorcycle.Application.Motorcycles.Results;
using RentMotorcycle.Data.MotorcycleAggregate;

namespace RentMotorcycle.Application.Motorcycles.CommandHandler
{
    public class MotorcycleCommandHandler : IRequestHandler<AddMotorcycleCommand, MotorcycleResult>,
        IRequestHandler<GetMotorcycleCommand, ListMotorcyclesResult>
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

        public async Task<ListMotorcyclesResult> Handle(GetMotorcycleCommand request, CancellationToken cancellationToken)
        {
            IList<Motorcycle>? motorcycles = new List<Motorcycle>();

            if (!string.IsNullOrEmpty(request.licensePlate))
            {
                var motorcycle = await _motorcycleRepository.GetByLicensePlate(request.licensePlate);

                if (motorcycle != null)
                    motorcycles.Add(motorcycle);

                return new ListMotorcyclesResult(motorcycles: motorcycles);
            }

            motorcycles = await _motorcycleRepository.GetMotorcycles();

            var teste = new ListMotorcyclesResult(motorcycles: motorcycles);
            return teste;
        }
    }
}
