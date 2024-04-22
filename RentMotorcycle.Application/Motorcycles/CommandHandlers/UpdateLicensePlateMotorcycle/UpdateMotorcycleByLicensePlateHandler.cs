using MediatR;
using RentMotorcycle.Application.Base;
using RentMotorcycle.Data.MotorcycleAggregate;

namespace RentMotorcycle.Application.Motorcycles.CommandHandlers.UpdateLicensePlateMotorcycle
{
    public class UpdateMotorcycleByLicensePlateHandler : IRequestHandler<UpdateLicensePlateMotorcycleCommand, BaseResult>
    {
        private readonly IMotorcycleRepository _motorcycleRepository;

        public UpdateMotorcycleByLicensePlateHandler(IMotorcycleRepository motorcycleRepository)
        {
            _motorcycleRepository = motorcycleRepository;
        }

        public async Task<BaseResult> Handle(UpdateLicensePlateMotorcycleCommand request, CancellationToken cancellationToken)
        {
            var motorcycleFound = await _motorcycleRepository.GetById(request.MotorcycleId);

            if (motorcycleFound == null)
                return new BaseResult(
                    false,
                    message: string.Format("Moto não foi encontrada no sistema!!"));

            motorcycleFound.LicensePlate = request.LicensePlate;
            var updatedMotorcycle = await _motorcycleRepository.UpdateAsync(motorcycleFound);

            return new BaseResult(true, result: updatedMotorcycle);
        }
    }
}
