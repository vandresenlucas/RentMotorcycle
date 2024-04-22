using Moq;
using RentMotorcycle.Application.Base;
using RentMotorcycle.Application.Motorcycles.CommandHandlers.UpdateLicensePlateMotorcycle;
using RentMotorcycle.Data.MotorcycleAggregate;

namespace RentMotorcycle.Application.Tests.Motorcycles
{
    public class UpdateLicensePlateMotorcycleHandlerTest
    {
        private readonly UpdateMotorcycleByLicensePlateHandler _handler;
        private readonly Mock<IMotorcycleRepository> _repositoryMock;

        public UpdateLicensePlateMotorcycleHandlerTest()
        {
            _repositoryMock = new Mock<IMotorcycleRepository>();
            _handler = new UpdateMotorcycleByLicensePlateHandler(_repositoryMock.Object);
        }

        [Fact]
        public async Task Handle_With_Valid_Motorcycle_Returns_Motorcycle_Result_With_Added_Motorcycle()
        {
            //Arrange
            var motorcycle = MotorcycleTestModels.MotorcycleDefault();
            var command = CommandMotorcycleTestModels.UpdateLicensePlateMotorcycleCommandDefault();

            _repositoryMock.Setup(repo => repo.GetById(command.MotorcycleId)).ReturnsAsync(motorcycle);
            motorcycle.LicensePlate = command.LicensePlate;
            _repositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Motorcycle>())).ReturnsAsync(motorcycle);

            //Act
            var result = await _handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.Success);
            Assert.Equal(motorcycle.LicensePlate, "123ABC");
            Assert.Equivalent(new BaseResult(result: motorcycle), result);
            _repositoryMock.Verify(repo => repo.GetById(motorcycle.Id), Times.Once);
            _repositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<Motorcycle>()), Times.Once);
        }

        [Fact]
        public async Task Handle_With_Not_Exists_Motorcycle_Returns_Motorcycle_Result_With_Error()
        {
            //Arrange
            var command = new UpdateLicensePlateMotorcycleCommand { MotorcycleId = Guid.NewGuid(), LicensePlate = "ASD123" };
            _repositoryMock.Setup(repo => repo.GetById(command.MotorcycleId)).ReturnsAsync((Motorcycle)null);

            //Act
            var result = await _handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.Success);
            Assert.Contains("Moto não foi encontrada no sistema!!", result.Message);
            _repositoryMock.Verify(repo => repo.GetById(command.MotorcycleId), Times.Once);
            _repositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<Motorcycle>()), Times.Never);
        }
    }
}
