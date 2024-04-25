using MassTransit.Initializers;
using RentMotorcycle.Application.Base;
using RentMotorcycle.Application.RentalMotorcycles.CommandHandlers.RentalMotorcycles;
using RentMotorcycle.Domain.RentalMotorcycleAggregate;

namespace RentMotorcycle.Application.RentalMotorcycles.Services
{
    public class RentalMotorcycleService : IRentalMotorcycleService
    {
        private readonly IRentalMotorcycleRepository _rentalMotorcycleRepository;

        public RentalMotorcycleService(IRentalMotorcycleRepository rentalMotorcycleRepository)
        {
            _rentalMotorcycleRepository = rentalMotorcycleRepository;
        }

        public async Task<RentalMotorcycle> AddRentalMotorcycle(AddRentalMotorcycleCommand command, int period)
        {
            var startDate = DateTime.UtcNow.AddDays(1);
            var endDate = startDate.AddDays(period);

            RentalMotorcycle rentalMotorcycle = new AddRentalMotorcycleCommand
            {
                DeliverymanId = command.DeliverymanId,
                RentalPlanId = command.RentalPlanId,
                StartDate = DateTime.SpecifyKind(startDate, DateTimeKind.Utc),
                EndDate = DateTime.SpecifyKind(endDate, DateTimeKind.Utc),
                EstimatedCompletionDate = DateTime.SpecifyKind(endDate, DateTimeKind.Utc),
                MotorcycleId = command.MotorcycleId
            };

            var newRentalMotorcycle = await _rentalMotorcycleRepository.AddAsync(rentalMotorcycle);

            return newRentalMotorcycle;
        }

        public async Task<BaseResult> CheckMotorcycleRental(Guid motorcycleId)
        {
            var motorcycleFreeforRent = await _rentalMotorcycleRepository.CheckMotorcycleRental(motorcycleId, DateTime.UtcNow.AddDays(15));

            if (motorcycleFreeforRent)
                return new BaseResult(false, "Moto já alugada nesta data!!");

            return new BaseResult(true, message: string.Empty);
        }
    }
}
