using MediatR;
using RentMotorcycle.Data.DeliveryManAggregate;
using RentMotorcycle.Data.LicenseTypeAggregate;
using RentMotorcycle.Domain.UserAggregate;

namespace RentMotorcycle.Application.Deliverymans
{
    public class AddDeliverymanCommand : IRequest<DeliverymanResult>
    {
        public string IdentifyCode { get; set; }
        public string Cnpj { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string LicenseDriverNumber { get; set; }
        public LicenseType LicenseType { get; set; }
        public string LicenseImage { get; set; }
        public Guid UserId { get; set; }


        public static implicit operator Deliveryman(AddDeliverymanCommand command)
        {
            if (command == null)
                return null;

            return new(
                command.IdentifyCode,
                command.Cnpj,
                command.DateOfBirth,
                command.LicenseDriverNumber,
                command.LicenseType,
                command.LicenseImage,
                command.UserId);
        }
    }
}
