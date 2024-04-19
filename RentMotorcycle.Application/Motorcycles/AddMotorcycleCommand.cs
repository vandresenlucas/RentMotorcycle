using MediatR;
using RentMotorcycle.Data.MotorcycleAggregate;

namespace RentMotorcycle.Application.Motorcycles
{
    public class AddMotorcycleCommand : IRequest<MotorcycleResult>
    {
        public string IdentifyCode { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }

        public static implicit operator Motorcycle(AddMotorcycleCommand command)
        {
            if (command == null)
                return null;
            
            return new(
                command.IdentifyCode,
                command.Year,
                command.Model,
                command.LicensePlate,
                DateTime.UtcNow);
        }
    }
}
