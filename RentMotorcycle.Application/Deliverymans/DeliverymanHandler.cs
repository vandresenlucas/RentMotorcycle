using MediatR;
using RentMotorcycle.Application.Deliverymans.Services;
using RentMotorcycle.Data.DeliveryManAggregate;
using RentMotorcycle.Data.MotorcycleAggregate;

namespace RentMotorcycle.Application.Deliverymans
{
    public class DeliverymanHandler : IRequestHandler<AddDeliverymanCommand, DeliverymanResult>
    {
        private readonly IDeliverymanRepository _deliverymanRepository;
        private readonly IDeliverymanService _deliverymanService;

        public DeliverymanHandler(
            IDeliverymanRepository deliverymanRepository, 
            IDeliverymanService deliverymanService)
        {
            _deliverymanRepository = deliverymanRepository;
            _deliverymanService = deliverymanService;
        }

        public async Task<DeliverymanResult> Handle(AddDeliverymanCommand request, CancellationToken cancellationToken)
        {
            Deliveryman deliveryman = request;

            var deliveryManduplicated = await _deliverymanService.VerifyDuplicatedDeliveryman(request.Cnpj, request.LicenseDriverNumber);

            if (!deliveryManduplicated.Success)
                return deliveryManduplicated;

            var newDeliveryman = await _deliverymanRepository.AddAsync(deliveryman);

            return new DeliverymanResult(deliveryman: newDeliveryman);
        }
    }
}
