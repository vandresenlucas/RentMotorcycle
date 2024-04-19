using MediatR;

namespace RentMotorcycle.Application.Deliverymans
{
    public class DeliverymanHandler : IRequestHandler<AddDeliverymanCommand, DeliverymanResult>
    {
        public Task<DeliverymanResult> Handle(AddDeliverymanCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
