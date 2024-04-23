using Microsoft.EntityFrameworkCore;
using RentMotorcycle.Domain.RentalMotorcycleAggregate;
using RentMotorcycle.Repository;

namespace RentMotorcycle.Data.Repositories
{
    public class RentalMotorcycleRepository : Repository<RentalMotorcycle>, IRentalMotorcycleRepository
    {
        public RentalMotorcycleRepository(RentMotorcycleContext context) : base(context)
        {
        }

        public async Task<IList<RentalMotorcycle>> GetRentalByMotorcycle(Guid motorcycleId)
            => await _context.Set<RentalMotorcycle>().Where(rm => rm.MotorcycleId.Equals(motorcycleId)).ToListAsync();
    }
}
