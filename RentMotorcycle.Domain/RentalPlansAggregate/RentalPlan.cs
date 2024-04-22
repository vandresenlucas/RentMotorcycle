using RentMotorcycle.Data.Base;

namespace RentMotorcycle.Domain.RentalPlansAggregate
{
    public class RentalPlan : EntityBase
    {
        public int Period { get; set; }
        public double Price { get; set; }
    }
}
