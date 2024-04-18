using RentMotorcycle.Data.MotorcycleAggregate;

namespace RentMotorcycle.Repository.Repositories
{
    public class MotorcycleRepository : Repository<Motorcycle>, IMotorcycleRepository
    {
        public MotorcycleRepository(RentMotorcycleContext context) : base(context)
        {
        }
    }
}
