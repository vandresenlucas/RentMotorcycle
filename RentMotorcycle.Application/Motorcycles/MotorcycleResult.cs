using RentMotorcycle.Application.Base;

namespace RentMotorcycle.Application.Motorcycles
{
    public class MotorcycleResult : BaseEntityResult
    {
        public string IdentifyCode { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
    }
}