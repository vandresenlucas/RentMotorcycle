using FluentValidation;
using RentMotorcycle.Application.RentalMotorcycles.CommandHandlers.RentalMotorcycles;

namespace RentMotorcycle.Application.RentalMotorcycles.Validators
{
    public class AddRentalMotorcycleValidator : AbstractValidator<AddRentalMotorcycleCommand>
    {
        public AddRentalMotorcycleValidator()
        {
            RuleFor(rentalMotorcycle => rentalMotorcycle.RentalPlanId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("O campo 'Plano' deve ser preenchido!!");

            RuleFor(rentalMotorcycle => rentalMotorcycle.DeliverymanId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("O campo 'Entregador' deve ser preenchido!!");
        }
    }
}
