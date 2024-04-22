using RentMotorcycle.Data.Base;

namespace RentMotorcycle.Data.DeliveryManAggregate
{
    public interface IDeliverymanRepository : IRepository<Deliveryman>
    {
        Task<Deliveryman?> GetByCnpj(string cnpj);
        Task<Deliveryman?> GetByLicenseDriverNumber(string licenseDriverNumber);
        Task<bool> VerifyExistsUserDeliveryman(Guid userId);
    }
}
