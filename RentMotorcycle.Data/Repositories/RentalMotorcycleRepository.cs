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

        public async Task<IList<RentalMotorcycle>> GetRentalMotorcycleByMotorcycle(Guid motorcycleId)
            => await _context.Set<RentalMotorcycle>().Where(rm => rm.MotorcycleId.Equals(motorcycleId)).ToListAsync();

        public async Task<bool> CheckMotorcycleRental(Guid motorcycleId, DateTime rentDate)
            => await _context.Set<RentalMotorcycle>().AnyAsync(rm => rm.MotorcycleId.Equals(motorcycleId) && (rentDate >= rm.StartDate && rentDate <= rm.EndDate));
    }
}
