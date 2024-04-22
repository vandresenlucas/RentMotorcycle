using MediatR;
using RentMotorcycle.Application.Motorcycles.Results;

namespace RentMotorcycle.Application.Motorcycles.CommandHandler
{
    public class GetMotorcycleCommand : IRequest<ListMotorcyclesResult>
    {
        public string? licensePlate { get; set; }
    }
}
