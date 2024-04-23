using RentMotorcycle.Application.RentalMotorcycles.CommandHandlers.RentalMotorcycles;
using RentMotorcycle.Domain.RentalPlansAggregate;

namespace RentMotorcycle.Application.Tests.RentalMotorcycles
{
    public static class RentalMotorcycleTestModels
    {
        public static AddRentalMotorcycleCommand RentalMotorcycleDefault(Guid deliverymanId, RentalPlan rentalPlan)
        {
            var startDate = DateTime.SpecifyKind(Convert.ToDateTime("2024-04-11"), DateTimeKind.Utc).AddDays(1);
            var endDate = startDate.AddDays(rentalPlan.Period);

            return new AddRentalMotorcycleCommand
            {
                DeliverymanId = deliverymanId,
                RentalPlanId = rentalPlan.Id,
                StartDate = startDate,
                EndDate = endDate,
                EstimatedCompletionDate = endDate
            };
        }
    }
}
