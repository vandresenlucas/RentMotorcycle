using FluentValidation;
using RentMotorcycle.Application.Motorcycles.CommandHandlers.AddMotorcycle;

namespace RentMotorcycle.Application.Motorcycles.Validators
{
    public class AddMotorcycleValidator : AbstractValidator<AddMotorcycleCommand>
    {
        public AddMotorcycleValidator()
        {
            RuleFor(motorcycle => motorcycle.IdentifyCode)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("O campo 'Identificador' deve ser preenchido!!")
                .MaximumLength(6)
                .WithMessage("O campo 'Identificador' deve ter no máximo 6 caracteres!!");

            RuleFor(motorcycle => motorcycle.Model)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("O campo 'Modelo' deve ser preenchido!!")
                .MaximumLength(30)
                .WithMessage("O campo 'Modelo' deve ter no máximo 30 caracteres!!");

            RuleFor(motorcycle => motorcycle.Year)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("O campo 'Ano' deve ser preenchido!!")
                .Must(year => year >= 1885)
                .WithMessage("Não existe nenhuma moto criada no ano informado!!")
                .Must(year => year < DateTime.Now.Year + 2)
                .WithMessage("Não existe nenhum modelo de moto criada no ano informado!!");

            RuleFor(motorcycle => motorcycle.LicensePlate)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("O campo 'Placa' deve ser preenchido!!")
                .MaximumLength(10)
                .WithMessage("O campo 'Placa' deve ter no máximo 10 caracteres!!");
        }
    }
}
