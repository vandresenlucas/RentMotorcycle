using RentMotorcycle.Data.Base;

namespace RentMotorcycle.Domain.RentalMotorcycleAggregate
{
    public interface IRentalMotorcycleRepository : IRepository<RentalMotorcycle>
    {
        Task<IList<RentalMotorcycle>> GetRentalMotorcycleByMotorcycle(Guid motorcycleId);
        Task<bool> CheckMotorcycleRental(Guid motorcycleId, DateTime rentDate);
    }
}
