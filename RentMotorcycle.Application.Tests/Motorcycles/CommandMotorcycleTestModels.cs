using RentMotorcycle.Application.Motorcycles.CommandHandlers.AddMotorcycle;
using RentMotorcycle.Application.Motorcycles.CommandHandlers.UpdateLicensePlateMotorcycle;

namespace RentMotorcycle.Application.Tests.Motorcycles
{
    public static class CommandMotorcycleTestModels
    {
        public static AddMotorcycleCommand AddMotorcycleCommandDefault()
            => new AddMotorcycleCommand
            {
                IdentifyCode = "123123",
                Year = 2024,
                LicensePlate = "ABC123",
                Model = "teste"
            };

        public static UpdateLicensePlateMotorcycleCommand UpdateLicensePlateMotorcycleCommandDefault()
            => new UpdateLicensePlateMotorcycleCommand
            {
                MotorcycleId = Guid.Parse("945a3c74-5a9d-4c40-b739-ca278a397683"),
                LicensePlate = "123ABC"
            };
    }
}
