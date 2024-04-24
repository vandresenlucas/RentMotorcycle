using RentMotorcycle.Application.Base;
using RentMotorcycle.Application.RentalMotorcycles.CommandHandlers.RentalMotorcycles;
using RentMotorcycle.Domain.RentalMotorcycleAggregate;

namespace RentMotorcycle.Application.RentalMotorcycles.Services
{
    public interface IRentalMotorcycleService
    {
        Task<RentalMotorcycle> AddRentalMotorcycle(AddRentalMotorcycleCommand command, int period);
        Task<BaseResult> CheckMotorcycleRental(Guid motorcycleID);
    }
}
