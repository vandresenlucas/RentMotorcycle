using RentMotorcycle.Data.Base;

namespace RentMotorcycle.Data.MotorcycleAggregate
{
    public class Motorcycle : EntityBase
    {
        public string IdentifyCode { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }

        public Motorcycle(
            string identifyCode, 
            int year, 
            string model, 
            string licensePlate,
            DateTime createdDate)
        {
            IdentifyCode = identifyCode;
            Year = year;
            Model = model;
            LicensePlate = licensePlate;
            CreatedDate = createdDate;
        }
    }
}
