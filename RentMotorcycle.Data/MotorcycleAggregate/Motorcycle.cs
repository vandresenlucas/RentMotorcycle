using RentMotorcycle.Data.Base;

namespace RentMotorcycle.Data.MotorcycleAggregate
{
    public class Motorcycle : EntityBase
    {
        public string IdentifyCode { get; set; }
        public DateTime Year { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
    }
}
