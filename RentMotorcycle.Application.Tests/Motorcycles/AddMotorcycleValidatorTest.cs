using FluentValidation.TestHelper;
using RentMotorcycle.Application.Motorcycles.CommandHandler;
using RentMotorcycle.Application.Motorcycles.Validators;

namespace RentMotorcycle.Application.Tests.Motorcycles
{
    public class AddMotorcycleValidatorTest
    {
        private readonly AddMotorcycleValidator _validator;

        public AddMotorcycleValidatorTest()
        {
            _validator = new AddMotorcycleValidator();
        }

        [Fact]
        public void IdentifyCode_When_Empty_Should_Have_Validation_Error()
        {
            //Arrange
            var command = new AddMotorcycleCommand { IdentifyCode = "" };

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
            var command = new AddMotorcycleCommand { IdentifyCode = "1234567" };

            //Act
            var result = _validator.TestValidate(command);

            //Assert
            result.ShouldHaveValidationErrorFor(m => m.IdentifyCode)
                .WithErrorMessage("O campo 'Identificador' deve ter no máximo 6 caracteres!!");
        }

        [Fact]
        public void Model_When_Empty_Should_Have_Validation_Error()
        {
            //Arrange
            var command = new AddMotorcycleCommand { Model = "" };

            //Act
            var result = _validator.TestValidate(command);

            //Assert
            result.ShouldHaveValidationErrorFor(m => m.Model)
                .WithErrorMessage("O campo 'Modelo' deve ser preenchido!!");
        }

        [Fact]
        public void Model_When_Exceeds_Max_Length_Should_Have_Validation_Error()
        {
            //Arrange
            var command = new AddMotorcycleCommand { Model = "1234567asdqweq1234564q8w97e9qw7e9qw4e65a4sd3a21sd3a1sd65a46w74eq98e7q9" };

            //Act
            var result = _validator.TestValidate(command);

            //Assert
            result.ShouldHaveValidationErrorFor(m => m.Model)
                .WithErrorMessage("O campo 'Modelo' deve ter no máximo 30 caracteres!!");
        }

        [Fact]
        public void Year_When_Empty_Should_Have_Validation_Error()
        {
            //Arrange
            var command = new AddMotorcycleCommand();

            //Act
            var result = _validator.TestValidate(command);

            //Assert
            result.ShouldHaveValidationErrorFor(m => m.Year)
                .WithErrorMessage("O campo 'Ano' deve ser preenchido!!");
        }

        [Fact]
        public void Year_When_Date_Less_Than_1885_Should_Have_Validation_Error()
        {
            //Arrange
            var command = new AddMotorcycleCommand { Year = 1850 };

            //Act
            var result = _validator.TestValidate(command);

            //Assert
            result.ShouldHaveValidationErrorFor(m => m.Year)
                .WithErrorMessage("Não existe nenhuma moto criada no ano informado!!");
        }

        [Fact]
        public void Year_When_Date_Greater_Than_Or_Equal_To_Two_Years_More_Than_This_year_Should_Have_Validation_Error()
        {
            //Arrange
            var command = new AddMotorcycleCommand { Year = 2026 };

            //Act
            var result = _validator.TestValidate(command);

            //Assert
            result.ShouldHaveValidationErrorFor(m => m.Year)
                .WithErrorMessage("Não existe nenhum modelo de moto criada no ano informado!!");
        }

        [Fact]
        public void LicensePlate_When_Empty_Should_Have_Validation_Error()
        {
            //Arrange
            var command = new AddMotorcycleCommand { LicensePlate = "" };

            //Act
            var result = _validator.TestValidate(command);

            //Assert
            result.ShouldHaveValidationErrorFor(m => m.LicensePlate)
                .WithErrorMessage("O campo 'Placa' deve ser preenchido!!");
        }

        [Fact]
        public void LicensePlate_When_Exceeds_Max_Length_Should_Have_Validation_Error()
        {
            //Arrange
            var command = new AddMotorcycleCommand { LicensePlate = "12345678910" };

            //Act
            var result = _validator.TestValidate(command);

            //Assert
            result.ShouldHaveValidationErrorFor(m => m.LicensePlate)
                .WithErrorMessage("O campo 'Placa' deve ter no máximo 10 caracteres!!");
        }
    }
}
