using RentMotorcycle.Domain.RentalPlansAggregate;
using RentMotorcycle.Repository;

namespace RentMotorcycle.Data.Repositories
{
    public class RentalPlanRepository : Repository<RentalPlan>, IRentalPlanRepository
    {
        public RentalPlanRepository(RentMotorcycleContext context) : base(context)
        {
        }
    }
}
