namespace RentMotorcycle.Application.Motorcycles.MessageBroker
{
    public class AddMotorcycleEvent
    {
        public string IdentifyCode { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
    }
}
