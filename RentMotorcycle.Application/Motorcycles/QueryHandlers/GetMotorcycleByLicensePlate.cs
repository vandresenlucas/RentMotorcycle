using MediatR;
using RentMotorcycle.Application.Base;

namespace RentMotorcycle.Application.Motorcycles.QueryHandlers
{
    public class GetMotorcycleByLicensePlate : IRequest<BaseResult>
    {
        public string? licensePlate { get; set; }
    }
}
