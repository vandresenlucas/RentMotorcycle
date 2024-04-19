using RentMotorcycle.Data.Base;
using RentMotorcycle.Data.LicenseTypeAggregate;
using RentMotorcycle.Domain.UserAggregate;

namespace RentMotorcycle.Data.DeliveryManAggregate
{
    public class Deliveryman : EntityBase
    {
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
