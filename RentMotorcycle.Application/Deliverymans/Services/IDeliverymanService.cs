using RentMotorcycle.Application.Base;
using RentMotorcycle.Data.DeliveryManAggregate;

namespace RentMotorcycle.Application.Deliverymans.Services
{
    public interface IDeliverymanService
    {
        Task<Deliveryman?> GetByCnpj(string cnpj);
        Task<Deliveryman?> GetByLicenseDriverNumber(string licenseDriverNumber);
        Task<BaseResult> VerifyDuplicatedDeliveryman(string cnpj, string licenseDriverNumber);
        Task<BaseResult> ValidateDeliverymaForRentMotorcycle(Guid deliverymanId);
    }
}
