using FluentValidation;
using RentMotorcycle.Application.Deliverymans.CommandHandlers;

namespace RentMotorcycle.Application.Deliverymans.Validators
{
    public class AddDeliverymanValidator : AbstractValidator<AddDeliverymanCommand>
    {
        public AddDeliverymanValidator()
        {
            RuleFor(deliveryman => deliveryman.IdentifyCode)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("O campo 'Identificador' deve ser preenchido!!")
                .MaximumLength(6)
                .WithMessage("O campo 'Identificador' deve ter no máximo 6 caracteres!!");

            RuleFor(deliveryman => deliveryman.Cnpj)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("O campo 'CNPJ' deve ser preenchido!!")
                .MaximumLength(18)
                .WithMessage("O campo 'CNPJ' deve ter no máximo 18 caracteres!!");

            RuleFor(deliveryman => deliveryman.DateOfBirth)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("O campo 'Data de nascimento' deve ser preenchido!!")
                .LessThan(DateTime.Today)
                .WithMessage("O campo 'Data de nascimento' não pode ser uma data futura!!");

            RuleFor(deliveryman => deliveryman.LicenseDriverNumber)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("O campo 'Número da CNH' deve ser preenchido!!")
                .MaximumLength(20)
                .WithMessage("O campo 'Número da CNH' deve ter no máximo 20 caracteres!!");

            RuleFor(deliveryman => deliveryman.LicenseType)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("O campo 'Tipo CNH' deve ser preenchido!!");
        }
    }
}
