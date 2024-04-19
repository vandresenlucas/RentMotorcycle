using RentMotorcycle.Application.Base;
using RentMotorcycle.Data.DeliveryManAggregate;
using RentMotorcycle.Data.LicenseTypeAggregate;
using RentMotorcycle.Domain.UserAggregate;

namespace RentMotorcycle.Application.Deliverymans
{
    public class DeliverymanResult : BaseEntityResult
    {
        public DeliverymanResult(
            bool success,
            string? message = null,
            Deliveryman deliveryman = null) : base(success, message)
        {
        }

        public Deliveryman? deliveryman { get; set; }
        public string IdentifyCode { get; set; }
        public string Cnpj { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string LicenseDriverNumber { get; set; }
        public LicenseType? LicenseType { get; set; }
        public string LicenseImage { get; set; }
        public Guid UserId { get; set; }
        public User UserFk { get; set; }
    }
}
