using MediatR;
using RentMotorcycle.Application.Base;

namespace RentMotorcycle.Application.RentalMotorcycles.CommandHandlers.CalculateRentalMotorcyclePrice
{
    public class CalculateRentalMotorcyclePriceCommand : IRequest<BaseResult>
    {
        public Guid RentalMotorcycleId { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
