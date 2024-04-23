using MediatR;
using RentMotorcycle.Application.Base;

namespace RentMotorcycle.Application.Motorcycles.CommandHandlers.DeleteMotorcycle
{
    public class DeleteMotorcycleCommand : IRequest<BaseResult>
    {
        public Guid MotorcycleId { get; set; }
    }
}
