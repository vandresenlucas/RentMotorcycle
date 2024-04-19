using MassTransit.Initializers;
using Microsoft.EntityFrameworkCore;
using RentMotorcycle.Data.DeliveryManAggregate;

namespace RentMotorcycle.Repository.Repositories
{
    public class DeliverymanRepository : Repository<Deliveryman>, IDeliverymanRepository
    {
        public DeliverymanRepository(RentMotorcycleContext context) : base(context)
        {
        }

        public async Task<Deliveryman?> GetByCnpj(string cnpj)
            => await _context.Set<Deliveryman>().FirstOrDefaultAsync(deliveryman => deliveryman.Cnpj.Equals(cnpj));

        public async Task<Deliveryman?> GetByLicenseDriverNumber(string licenseDriverNumber)
            => await _context.Set<Deliveryman>().FirstOrDefaultAsync(deliveryman => deliveryman.LicenseDriverNumber.Equals(licenseDriverNumber));

        public async Task<bool> VerifyExistsUserDeliveryman(Guid userId)
            => await _context.Set<Deliveryman>().AnyAsync(deliveryman => deliveryman.UserId == userId);


    }
}
