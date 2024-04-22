using MediatR;
using RentMotorcycle.Application.Base;

namespace RentMotorcycle.Application.Motorcycles.QueryHandlers
{
    public class MotorcycleGetByLicensePlate : IRequest<BaseResult>
    {
        public string? licensePlate { get; set; }
    }
}
