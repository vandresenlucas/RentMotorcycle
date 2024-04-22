using MediatR;
using RentMotorcycle.Application.Base;
using RentMotorcycle.Data.DeliveryManAggregate;
using RentMotorcycle.Data.LicenseTypeAggregate;

namespace RentMotorcycle.Application.Deliverymans.CommandHandlers
{
    public class AddDeliverymanCommand : IRequest<BaseResult>
    {
        public string IdentifyCode { get; set; }
        public string Cnpj { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string LicenseDriverNumber { get; set; }
        public LicenseType LicenseType { get; set; }
        public string? LicenseImage { get; set; }
        public Guid UserId { get; set; }


        public static implicit operator Deliveryman(AddDeliverymanCommand command)
        {
            if (command == null)
                return null;

            return new(
                command.IdentifyCode,
                command.Cnpj,
                DateTime.SpecifyKind(command.DateOfBirth, DateTimeKind.Utc),
                command.LicenseDriverNumber,
                command.LicenseType,
                command.LicenseImage,
                DateTime.UtcNow,
                command.UserId);
        }
    }
}
