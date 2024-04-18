using RentMotorcycle.Domain.Repositories;

namespace RentMotorcycle.Data.MotorcycleAggregate
{
    public interface IMotorcycleRepository : IRepository<Motorcycle>
    {
        Task<Motorcycle?> GetByLicensePlate(string licensePlate);
    }
}
