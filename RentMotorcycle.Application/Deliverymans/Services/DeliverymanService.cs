using RentMotorcycle.Data.DeliveryManAggregate;

namespace RentMotorcycle.Application.Deliverymans.Services
{
    public class DeliverymanService : IDeliverymanService
    {
        private readonly IDeliverymanRepository _deliverymanRepository;

        public DeliverymanService(IDeliverymanRepository deliverymanRepository)
        {
            _deliverymanRepository = deliverymanRepository;
        }

        public async Task<Deliveryman?> GetByCnpj(string cnpj)
            => await _deliverymanRepository.GetByCnpj(cnpj);

        public async Task<Deliveryman?> GetByLicenseDriverNumber(string licenseDriverNumber)
            => await _deliverymanRepository.GetByLicenseDriverNumber(licenseDriverNumber);
    }
}
