using Microsoft.EntityFrameworkCore;
using RentMotorcycle.Data.MotorcycleAggregate;

namespace RentMotorcycle.Repository.Repositories
{
    public class MotorcycleRepository : Repository<Motorcycle>, IMotorcycleRepository
    {
        public MotorcycleRepository(RentMotorcycleContext context) : base(context)
        {
        }

        public async Task<Motorcycle?> GetByLicensePlate(string licensePlate)
            => await _context.Set<Motorcycle>().FirstOrDefaultAsync(motorcycle => motorcycle.LicensePlate.Equals(licensePlate));

        public async Task<List<Motorcycle>> GetMotorcycles()
            => await _context.Set<Motorcycle>().Select(motorcycle => motorcycle).ToListAsync();
    }
}
