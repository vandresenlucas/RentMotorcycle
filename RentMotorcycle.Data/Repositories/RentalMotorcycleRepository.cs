using RentMotorcycle.Domain.RentalMotorcycleAggregate;
using RentMotorcycle.Repository;

namespace RentMotorcycle.Data.Repositories
{
    public class RentalMotorcycleRepository : Repository<RentalMotorcycle>, IRentalMotorcycleRepository
    {
        public RentalMotorcycleRepository(RentMotorcycleContext context) : base(context)
        {
        }
    }
}
