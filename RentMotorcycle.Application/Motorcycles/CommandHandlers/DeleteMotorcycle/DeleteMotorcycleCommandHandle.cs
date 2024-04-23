using MediatR;
using RentMotorcycle.Application.Base;
using RentMotorcycle.Data.MotorcycleAggregate;
using RentMotorcycle.Domain.RentalMotorcycleAggregate;

namespace RentMotorcycle.Application.Motorcycles.CommandHandlers.DeleteMotorcycle
{
    public class DeleteMotorcycleCommandHandle : IRequestHandler<DeleteMotorcycleCommand, BaseResult>
    {
        private readonly IMotorcycleRepository _motorcycleRepository;
        private readonly IRentalMotorcycleRepository _rentalMotorcycleRepository;

        public DeleteMotorcycleCommandHandle(IMotorcycleRepository motorcycleRepository, IRentalMotorcycleRepository rentalMotorcycleRepository)
        {
            _motorcycleRepository = motorcycleRepository;
            _rentalMotorcycleRepository = rentalMotorcycleRepository;
        }

        public async Task<BaseResult> Handle(DeleteMotorcycleCommand request, CancellationToken cancellationToken)
        {
            var rentalMotorcycleFound = await _rentalMotorcycleRepository.GetRentalByMotorcycle(request.MotorcycleId);

            if (rentalMotorcycleFound.Count > 0)
                return new BaseResult(false, message: "A moto selecionada possuí registro(s) de locação(ões)!!");

            await _motorcycleRepository.DeleteAsync(request.MotorcycleId);

            return new BaseResult(true, message: "Moto excluída com sucesso!!");
        }
    }
}
