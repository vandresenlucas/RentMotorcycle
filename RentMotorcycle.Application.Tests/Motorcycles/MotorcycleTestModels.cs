using RentMotorcycle.Data.MotorcycleAggregate;

namespace RentMotorcycle.Application.Tests.Motorcycles
{
    public static class MotorcycleTestModels
    {
        public static Motorcycle MotorcycleDefault()
            => new Motorcycle(
                "123123",
                2024,
                "teste",
                "ABC123",
                Convert.ToDateTime("2024-04-01")
                );
    }
}
