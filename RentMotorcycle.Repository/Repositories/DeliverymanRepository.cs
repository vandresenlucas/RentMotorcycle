using RentMotorcycle.Data.DeliveryManAggregate;

namespace RentMotorcycle.Repository.Repositories
{
    public class DeliverymanRepository : Repository<Deliveryman>, IDeliverymanRepository
    {
        public DeliverymanRepository(RentMotorcycleContext context) : base(context)
        {
        }
    }
}
