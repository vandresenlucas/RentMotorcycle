using FluentValidation;
using RentMotorcycle.Application.Users.CommandHandlers;
using RentMotorcycle.Data.ProfileAggregate;
using System.Text.RegularExpressions;

namespace RentMotorcycle.Application.Users.Validators
{
    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserValidator()
        {
            RuleFor(user => user.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("O campo 'Nome' deve ser preenchido!!")
                .MaximumLength(50)
                .WithMessage("O campo 'Nome' deve ter no máximo 50 caracteres!!");

            RuleFor(user => user.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("O campo 'Email' deve ser preenchido!!")
                .MaximumLength(50)
                .WithMessage("O campo 'Email' deve ter no máximo 50 caracteres!!")
                .Must(email => IsEmail(email));

            RuleFor(user => user.Password)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("O campo 'Senha' deve ser preenchido!!")
                .MaximumLength(100)
                .WithMessage("O campo 'Senha' deve ter no máximo 100 caracteres!!");

            RuleFor(user => user.Profile)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("O campo 'Perfil' deve ser preenchido!!")
                .Must(profile => profile == Profile.Admin || profile == Profile.Deliveryman)
                .WithMessage("O campo 'Perfil' é inválido!!");
        }

        public bool IsEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            string regexEmail = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

            return Regex.IsMatch(email, regexEmail);
        }
    }
}
