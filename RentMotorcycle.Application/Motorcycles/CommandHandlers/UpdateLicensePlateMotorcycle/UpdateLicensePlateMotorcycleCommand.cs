using MediatR;
using RentMotorcycle.Application.Base;

namespace RentMotorcycle.Application.Motorcycles.CommandHandlers.UpdateLicensePlateMotorcycle
{
    public class UpdateLicensePlateMotorcycleCommand : IRequest<BaseResult>
    {
        public Guid MotorcycleId;
        public string LicensePlate { get; set; }
    }
}
