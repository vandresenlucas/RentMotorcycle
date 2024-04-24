using MediatR;
using RentMotorcycle.Application.Base;
using RentMotorcycle.Domain.RentalMotorcycleAggregate;
using RentMotorcycle.Domain.RentalPlansAggregate;

namespace RentMotorcycle.Application.RentalMotorcycles.CommandHandlers.CalculateRentalMotorcyclePrice
{
    public class CalculateRentalMotorcyclePriceCommandHandler : IRequestHandler<CalculateRentalMotorcyclePriceCommand, BaseResult>
    {
        private readonly IRentalMotorcycleRepository _rentalMotorcycleRepository;
        private readonly IRentalPlanRepository _rentalPlanRepository;

        public CalculateRentalMotorcyclePriceCommandHandler(IRentalMotorcycleRepository rentalMotorcycleRepository, IRentalPlanRepository rentalPlanRepository)
        {
            _rentalMotorcycleRepository = rentalMotorcycleRepository;
            _rentalPlanRepository = rentalPlanRepository;
        }

        public async Task<BaseResult> Handle(CalculateRentalMotorcyclePriceCommand request, CancellationToken cancellationToken)
        {
            double amount;
            double amountFined;
            double amountCharged;

            var rentalMotorcycle = await _rentalMotorcycleRepository.GetByIdAsync(request.RentalMotorcycleId);
            var rentalPlan = await _rentalPlanRepository.GetByIdAsync(rentalMotorcycle.RentalPlanId);

            if (request.ReturnDate.Date < rentalMotorcycle.EstimatedCompletionDate.Date) 
            {
                var daysAdvance = rentalMotorcycle.EstimatedCompletionDate - request.ReturnDate;
                var daysToBeCharge = rentalPlan.Period - daysAdvance.Days;
                var plan15DaysFine = rentalPlan.Period == 15 ? 0.4 : 0;
                var percentageFine = rentalPlan.Period == 7 ? 0.2 : plan15DaysFine;
                amountFined = daysAdvance.Days * (rentalPlan.Price * percentageFine);
                amountCharged = daysToBeCharge * rentalPlan.Price;

                amount = amountCharged + amountFined;

                return new BaseResult(true, message: $"O valor total da locação é de R$: {amount.ToString("n2")}, " +
                    $"sendo R$: {amountCharged.ToString("n2")} de diárias e R$: {amountFined.ToString("n2")} de multas!!");
            } else if (request.ReturnDate.Date == rentalMotorcycle.EstimatedCompletionDate.Date)
            {
                amount = rentalPlan.Price * rentalPlan.Period;

                return new BaseResult(true, message: $"O valor total da locação é de R$: {amount.ToString("n2")}");
            } else
            {
                var pastDays = request.ReturnDate.Day - rentalMotorcycle.EstimatedCompletionDate.Day;

                amountFined = 50 * pastDays;
                amountCharged = rentalPlan.Price * rentalPlan.Period;
                amount = amountCharged + amountFined;

                return new BaseResult(true, message: $"O valor total da locação é de R$: {amount.ToString("n2")}, " +
                    $"sendo R$: {amountCharged.ToString("n2")} de diárias e R$: {amountFined.ToString("n2")} de multas!!");
            }
        }
    }
}
