using RentMotorcycle.Data.MotorcycleAggregate;

namespace RentMotorcycle.Application.Tests.Motorcycles
{
    public static class MotorcycleTestModels
    {
        public static Motorcycle MotorcycleDefault()
        {
            var motorcycle =
                new Motorcycle(
                    "123123",
                    2024,
                    "teste",
                    "ABC123",
                    Convert.ToDateTime("2024-04-01")
            );

            motorcycle.Id = Guid.Parse("945a3c74-5a9d-4c40-b739-ca278a397683");

            return motorcycle;
        }
    }
}
