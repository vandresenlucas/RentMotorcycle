using RentMotorcycle.Data.Base;

namespace RentMotorcycle.Domain.RentalMotorcycleAggregate
{
    public interface IRentalMotorcycleRepository : IRepository<RentalMotorcycle>
    {
        Task<IList<RentalMotorcycle>> GetRentalByMotorcycle(Guid motorcycleId);
    }
}
