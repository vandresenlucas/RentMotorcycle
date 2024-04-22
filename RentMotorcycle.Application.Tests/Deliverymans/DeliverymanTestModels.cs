using RentMotorcycle.Data.DeliveryManAggregate;
using RentMotorcycle.Data.LicenseTypeAggregate;

namespace RentMotorcycle.Application.Tests.Deliverymans
{
    public static class DeliverymanTestModels
    {
        public static Deliveryman DeliverymanDefault()
            => new Deliveryman(
                "123123",
                "123456789123",
                Convert.ToDateTime("15/04/1998"),
                "123141231",
                LicenseType.A,
                null,
                DateTime.SpecifyKind(Convert.ToDateTime("2024-04-21"), DateTimeKind.Utc),
                Guid.NewGuid()
                );
    }
}
