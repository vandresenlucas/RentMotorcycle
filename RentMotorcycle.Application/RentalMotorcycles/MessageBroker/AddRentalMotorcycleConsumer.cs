using MassTransit;
using MediatR;
using RentMotorcycle.Application.RentalMotorcycles.CommandHandlers.RentalMotorcycles;

namespace RentMotorcycle.Application.RentalMotorcycles.MessageBroker
{
    public class AddRentalMotorcycleConsumer : IConsumer<AddRentalMotorcycleEvent>
    {
        private readonly IMediator _mediator;

        public AddRentalMotorcycleConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<AddRentalMotorcycleEvent> context)
        {
            var command = new AddRentalMotorcycleCommand
            {
                DeliverymanId = context.Message.DeliverymanId,
                MotorcycleId = context.Message.MotorcycleId,
                RentalPlanId = context.Message.RentalPlanId
            };

            _ = await _mediator.Send(command);
        }
    }
}
