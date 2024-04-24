namespace RentMotorcycle.Application.RentalMotorcycles.MessageBroker
{
    public class AddRentalMotorcycleEvent
    {
        public Guid RentalPlanId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime EstimatedCompletionDate { get; set; }
        public Guid DeliverymanId { get; set; }
        public Guid MotorcycleId { get; set; }
    }
}
