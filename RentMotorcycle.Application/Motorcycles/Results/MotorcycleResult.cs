using RentMotorcycle.Application.Base;
using RentMotorcycle.Data.MotorcycleAggregate;

namespace RentMotorcycle.Application.Motorcycles.Results
{
    public class MotorcycleResult : BaseEntityResult
    {
        public MotorcycleResult(
            bool success = true,
            string? message = null,
            Motorcycle? motorcycle = null) : base(success, message)
        {
        }

        public Motorcycle? motorcycle { get; set; }
        public string IdentifyCode { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
    }
}