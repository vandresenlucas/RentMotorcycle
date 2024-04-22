using RentMotorcycle.Data.Base;

namespace RentMotorcycle.Data.MotorcycleAggregate
{
    public interface IMotorcycleRepository : IRepository<Motorcycle>
    {
        Task<Motorcycle?> GetByLicensePlate(string licensePlate);
        Task<IList<Motorcycle>> GetMotorcycles();
    }
}
