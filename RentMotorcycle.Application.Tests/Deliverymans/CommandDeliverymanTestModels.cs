using RentMotorcycle.Application.Deliverymans;
using RentMotorcycle.Data.LicenseTypeAggregate;

namespace RentMotorcycle.Application.Tests.Deliverymans
{
    public static class CommandDeliverymanTestModels
    {
        public static AddDeliverymanCommand AddDeliverymanCommandDefault()
            => new AddDeliverymanCommand
            {
                Cnpj = "123456789",
                DateOfBirth = Convert.ToDateTime("15/11/1995"),
                IdentifyCode = "123456",
                LicenseDriverNumber = "123456798",
                LicenseType = LicenseType.A,
                UserId = Guid.Parse("bffe3ee2-5681-49bf-bef8-fa8ad3319199")
            };
    }
}
