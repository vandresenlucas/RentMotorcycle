using MediatR;
using RentMotorcycle.Application.Base;
using RentMotorcycle.Domain.RentalMotorcycleAggregate;

namespace RentMotorcycle.Application.RentalMotorcycles.CommandHandlers.RentalMotorcycles
{
    public class AddRentalMotorcycleCommand : IRequest<BaseResult>
    {
        public Guid RentalPlanId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime EstimatedCompletionDate { get; set; }
        public Guid DeliverymanId { get; set; }

        public static implicit operator RentalMotorcycle(AddRentalMotorcycleCommand command)
        {
            if (command == null)
                return null;

            return new(
                command.RentalPlanId,
                command.StartDate,
                command.EndDate,
                command.EstimatedCompletionDate,
                command.DeliverymanId,
                DateTime.UtcNow
            );
        }
    }
}
