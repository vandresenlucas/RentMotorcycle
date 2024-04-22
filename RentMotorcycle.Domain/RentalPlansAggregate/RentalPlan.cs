using RentMotorcycle.Data.Base;

namespace RentMotorcycle.Domain.RentalPlansAggregate
{
    public class RentalPlan : EntityBase
    {
        public RentalPlan(int period, double price, DateTime createdDate)
        {
            Period = period;
            Price = price;
            CreatedDate = createdDate;
        }

        public int Period { get; set; }
        public double Price { get; set; }
    }
}
