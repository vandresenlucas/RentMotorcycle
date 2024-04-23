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
                StartDate = startDate,
                EndDate = endDate,
                EstimatedCompletionDate = endDate
            };

            var newRentalMotorcycle = await _rentalMotorcycleRepository.AddAsync(rentalMotorcycle);

            return newRentalMotorcycle;
        }
    }
}
