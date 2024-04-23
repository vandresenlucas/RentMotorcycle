using RentMotorcycle.Data.Base;
using RentMotorcycle.Data.DeliveryManAggregate;
using RentMotorcycle.Data.MotorcycleAggregate;
using RentMotorcycle.Domain.RentalPlansAggregate;

namespace RentMotorcycle.Domain.RentalMotorcycleAggregate
{
    public class RentalMotorcycle : EntityBase
    {
        public RentalMotorcycle(
            Guid rentalPlanId, 
            DateTime startDate, 
            DateTime endDate, 
            DateTime estimatedCompletionDate, 
            Guid deliverymanId,
            Guid motorcycleId,
            DateTime createdDate)
        {
            RentalPlanId = rentalPlanId;
            StartDate = startDate;
            EndDate = endDate;
            EstimatedCompletionDate = estimatedCompletionDate;
            DeliverymanId = deliverymanId;
            MotorcycleId = motorcycleId;
            CreatedDate = createdDate;
        }

        public RentalPlan RentalPlanFk { get; set; }
        public Guid RentalPlanId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime EstimatedCompletionDate { get; set; }
        public Deliveryman DeliverymanFk { get; set; }
        public Guid DeliverymanId { get; set; }
        public Motorcycle MotorcycleFk { get; set; }
        public Guid MotorcycleId { get; set; }
    }
}
