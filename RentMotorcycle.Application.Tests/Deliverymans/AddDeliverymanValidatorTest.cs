using FluentValidation.TestHelper;
using RentMotorcycle.Application.Deliverymans.CommandHandlers;
using RentMotorcycle.Application.Deliverymans.Validators;

namespace RentMotorcycle.Application.Tests.Deliverymans
{
    public class AddDeliverymanValidatorTest
    {
        private readonly AddDeliverymanValidator _validator;

        public AddDeliverymanValidatorTest()
        {
            _validator = new AddDeliverymanValidator();
        }

        [Fact]
        public void IdentifyCode_When_Empty_Should_Have_Validation_Error()
        {
            //Arrange
            var command = new AddDeliverymanCommand { IdentifyCode = "" };

            //Act
            var result = _validator.TestValidate(command);

            //Assert
            result.ShouldHaveValidationErrorFor(m => m.IdentifyCode)
                .WithErrorMessage("O campo 'Identificador' deve ser preenchido!!");
        }

        [Fact]
        public void IdentifyCode_When_Exceeds_Max_Length_Should_Have_Validation_Error()
        {
            //Arrange
            var command = new AddDeliverymanCommand { IdentifyCode = "1234567" };

            //Act
            var result = _validator.TestValidate(command);

            //Assert
            result.ShouldHaveValidationErrorFor(m => m.IdentifyCode)
                .WithErrorMessage("O campo 'Identificador' deve ter no máximo 6 caracteres!!");
        }

        [Fact]
        public void Cnpj_When_Empty_Should_Have_Validation_Error()
        {
            //Arrange
            var command = new AddDeliverymanCommand { Cnpj = "" };

            //Act
            var result = _validator.TestValidate(command);

            //Assert
            result.ShouldHaveValidationErrorFor(m => m.Cnpj)
                .WithErrorMessage("O campo 'CNPJ' deve ser preenchido!!");
        }

        [Fact]
        public void Cnpj_When_Exceeds_Max_Length_Should_Have_Validation_Error()
        {
            //Arrange
            var command = new AddDeliverymanCommand { Cnpj = "123456789101112131415" };

            //Act
            var result = _validator.TestValidate(command);

            //Assert
            result.ShouldHaveValidationErrorFor(m => m.Cnpj)
                .WithErrorMessage("O campo 'CNPJ' deve ter no máximo 18 caracteres!!");
        }

        [Fact]
        public void DateOfBirth_When_Empty_Should_Have_Validation_Error()
        {
            //Arrange
            var command = new AddDeliverymanCommand();

            //Act
            var result = _validator.TestValidate(command);

            //Assert
            result.ShouldHaveValidationErrorFor(m => m.DateOfBirth)
                .WithErrorMessage("O campo 'Data de nascimento' deve ser preenchido!!");
        }

        [Fact]
        public void DateOfBirth_When_Exceeds_Max_Length_Should_Have_Validation_Error()
        {
            //Arrange
            var command = new AddDeliverymanCommand { DateOfBirth = DateTime.Today.AddDays(2) };

            //Act
            var result = _validator.TestValidate(command);

            //Assert
            result.ShouldHaveValidationErrorFor(m => m.DateOfBirth)
                .WithErrorMessage("O campo 'Data de nascimento' não pode ser uma data futura!!");
        }

        [Fact]
        public void LicenseDriverNumber_When_Empty_Should_Have_Validation_Error()
        {
            //Arrange
            var command = new AddDeliverymanCommand { LicenseDriverNumber = "" };

            //Act
            var result = _validator.TestValidate(command);

            //Assert
            result.ShouldHaveValidationErrorFor(m => m.LicenseDriverNumber)
                .WithErrorMessage("O campo 'Número da CNH' deve ser preenchido!!");
        }

        [Fact]
        public void LicenseDriverNumber_When_Exceeds_Max_Length_Should_Have_Validation_Error()
        {
            //Arrange
            var command = new AddDeliverymanCommand { LicenseDriverNumber = "1234567891011121314151617" };

            //Act
            var result = _validator.TestValidate(command);

            //Assert
            result.ShouldHaveValidationErrorFor(m => m.LicenseDriverNumber)
                .WithErrorMessage("O campo 'Número da CNH' deve ter no máximo 20 caracteres!!");
        }

        [Fact]
        public void LicenseType_When_Empty_Should_Have_Validation_Error()
        {
            //Arrange
            var command = new AddDeliverymanCommand();

            //Act
            var result = _validator.TestValidate(command);

            //Assert
            result.ShouldHaveValidationErrorFor(m => m.LicenseType)
                .WithErrorMessage("O campo 'Tipo CNH' deve ser preenchido!!");
        }
    }
}
