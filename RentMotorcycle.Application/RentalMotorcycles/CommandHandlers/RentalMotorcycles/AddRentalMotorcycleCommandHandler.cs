using MediatR;
using RentMotorcycle.Application.Base;
using RentMotorcycle.Application.Deliverymans.Services;
using RentMotorcycle.Application.RentalMotorcycles.Services;
using RentMotorcycle.Domain.RentalPlansAggregate;

namespace RentMotorcycle.Application.RentalMotorcycles.CommandHandlers.RentalMotorcycles
{
    public class AddRentalMotorcycleCommandHandler : IRequestHandler<AddRentalMotorcycleCommand, BaseResult>
    {
        private readonly IRentalMotorcycleService _rentalMotorcycleService;
        private readonly IRentalPlanRepository _rentalPlanRepository;
        private readonly IDeliverymanService _deliverymanService;

        public AddRentalMotorcycleCommandHandler(
            IRentalMotorcycleService rentalMotorcycleService, 
            IRentalPlanRepository rentalPlanRepository,
            IDeliverymanService deliverymanService)
        {
            _rentalMotorcycleService = rentalMotorcycleService;
            _rentalPlanRepository = rentalPlanRepository;
            _deliverymanService = deliverymanService;
        }

        public async Task<BaseResult> Handle(AddRentalMotorcycleCommand request, CancellationToken cancellationToken)
        {
            var rentalPlanFound = await _rentalPlanRepository.GetById(request.RentalPlanId);

            if (rentalPlanFound == null)
                return new BaseResult(false, "O Plano informando não foi encontrado no sistema!!");

            var validDeliverymanResult = await _deliverymanService.ValidateDeliverymaForRentMotorcycle(request.DeliverymanId);

            if (!validDeliverymanResult.Success)
                return validDeliverymanResult;

            var rentalMotorcycle = await _rentalMotorcycleService.AddRentalMotorcycle(request, rentalPlanFound.Period);

            return new BaseResult(true, result: rentalMotorcycle);
        }
    }
}
