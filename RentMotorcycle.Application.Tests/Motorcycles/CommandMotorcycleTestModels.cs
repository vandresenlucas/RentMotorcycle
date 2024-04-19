using RentMotorcycle.Application.Motorcycles;

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
    }
}
