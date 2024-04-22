using RentMotorcycle.Application.Base;
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

        public async Task<BaseResult> VerifyDuplicatedDeliveryman(string cnpj, string licenseDriverNumber)
        {
            if (await GetByCnpj(cnpj) != null)
                return new BaseResult(
                    false,
                    message: string.Format($"O entregador com CNPJ '{cnpj}', já está cadastrado no sistema!!"));

            if (await GetByLicenseDriverNumber(licenseDriverNumber) != null)
                return new BaseResult(
                    false,
                    message: string.Format($"O entregador com Número do CNH '{licenseDriverNumber}', já está cadastrado no sistema!!"));

            return new BaseResult(true, null);
        }
    }
}
