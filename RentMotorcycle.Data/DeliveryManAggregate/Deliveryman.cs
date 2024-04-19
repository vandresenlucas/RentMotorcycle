using RentMotorcycle.Data.Base;
using RentMotorcycle.Data.ProfileAggregate;

namespace RentMotorcycle.Data.DeliveryManAggregate
{
    public class Deliveryman : EntityBase
    {
        public string IdentityCode { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; } = null;
        public string LicenseDriverNumber { get; set; } = string.Empty;
        public LicenseType? LicenseType { get; set; } = null;
        public string LicenseImage { get; set; } = string.Empty;
    }
}
