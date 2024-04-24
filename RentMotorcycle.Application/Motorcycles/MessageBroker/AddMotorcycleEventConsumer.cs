using MassTransit;
using MediatR;
using RentMotorcycle.Application.Motorcycles.CommandHandlers.AddMotorcycle;

namespace RentMotorcycle.Application.Motorcycles.MessageBroker
{
    public class AddMotorcycleEventConsumer : IConsumer<AddMotorcycleEvent>
    {
        private readonly IMediator _mediator;

        public AddMotorcycleEventConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<AddMotorcycleEvent> context)
        {
            var command = new AddMotorcycleCommand {
                IdentifyCode = context.Message.IdentifyCode,
                LicensePlate = context.Message.LicensePlate,
                Year = context.Message.Year,
                Model = context.Message.Model
            };

            _ = await _mediator.Send(command);
        }
    }
}
