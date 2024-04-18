using FluentValidation;

namespace RentMotorcycle.Application.Motorcycles
{
    public class AddMotorcycleValidator : AbstractValidator<AddMotorcycleCommand>
    {
        public AddMotorcycleValidator()
        {
            RuleFor(motorcycle => motorcycle.IdentifyCode)
                .NotNull()
                .NotEmpty()
                .WithMessage("O campo 'Identificador' deve ser preenchido!!");

            RuleFor(motorcycle => motorcycle.Model)
                .NotNull()
                .NotEmpty()
                .WithMessage("O campo 'Modelo' deve ser preenchido!!");

            RuleFor(motorcycle => motorcycle.Year)
                .NotNull()
                .NotEmpty()
                .WithMessage("O campo 'Ano' deve ser preenchido!!");

            RuleFor(motorcycle => motorcycle.LicensePlate)
                .NotNull()
                .NotEmpty()
                .WithMessage("O campo 'Placa' deve ser preenchido!!");
        }
    }
}
