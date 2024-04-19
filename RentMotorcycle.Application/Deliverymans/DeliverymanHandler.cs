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

            if (await _deliverymanService.GetByCnpj(deliveryman.Cnpj) != null)
                return new DeliverymanResult(
                    false,
                    message: string.Format($"O entregador com CNPJ '{deliveryman.Cnpj}', já está cadastrado no sistema!!"));

            if (await _deliverymanService.GetByCnpj(deliveryman.LicenseDriverNumber) != null)
                return new DeliverymanResult(
                    false,
                    message: string.Format($"O entregador com CNPJ '{deliveryman.Cnpj}', já está cadastrado no sistema!!"));

            var newDeliveryman = await _deliverymanRepository.AddAsync(deliveryman);

            return new DeliverymanResult(deliveryman: newDeliveryman);
        }
    }
}
