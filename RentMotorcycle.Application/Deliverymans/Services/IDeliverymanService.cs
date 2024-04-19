using RentMotorcycle.Data.DeliveryManAggregate;

namespace RentMotorcycle.Application.Deliverymans.Services
{
    public interface IDeliverymanService
    {
        Task<Deliveryman?> GetByCnpj(string cnpj);
        Task<Deliveryman?> GetByLicenseDriverNumber(string licenseDriverNumber);
    }
}
