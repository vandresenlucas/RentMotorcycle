using RentMotorcycle.Data.Base;
using RentMotorcycle.Data.LicenseTypeAggregate;
using RentMotorcycle.Data.UserAggregate;

namespace RentMotorcycle.Data.DeliveryManAggregate
{
    public class Deliveryman : EntityBase
    {
        public Deliveryman(
            string identifyCode, 
            string cnpj, 
            DateTime dateOfBirth, 
            string licenseDriverNumber, 
            LicenseType licenseType, 
            string licenseImage,
            DateTime createdDate,
            Guid userId)
        {
            IdentifyCode = identifyCode;
            Cnpj = cnpj;
            DateOfBirth = dateOfBirth;
            LicenseDriverNumber = licenseDriverNumber;
            LicenseType = licenseType;
            LicenseImage = licenseImage;
            UserId = userId;
            CreatedDate = createdDate;
        }

        public string IdentifyCode { get; set; }
        public string Cnpj { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string LicenseDriverNumber { get; set; }
        public LicenseType LicenseType { get; set; }
        public string? LicenseImage { get; set; }
        public Guid UserId { get; set; }
        public User UserFk { get; set; }
    }
}
