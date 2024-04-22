using Moq;
using RentMotorcycle.Application.Base;
using RentMotorcycle.Application.Motorcycles.CommandHandlers.AddMotorcycle;
using RentMotorcycle.Data.MotorcycleAggregate;

namespace RentMotorcycle.Application.Tests.Motorcycles
{
    public class MotorcycleCommandHandleTest
    {
        private readonly AddMotorcycleCommandHandler _handler;
        private readonly Mock<IMotorcycleRepository> _repositoryMock;

        public MotorcycleCommandHandleTest()
        {
            _repositoryMock = new Mock<IMotorcycleRepository>();
            _handler = new AddMotorcycleCommandHandler(_repositoryMock.Object);
        }

        [Fact]
        public async Task Handle_With_Valid_Motorcycle_Returns_Motorcycle_Result_With_Added_Motorcycle()
        {
            //Arrange
            var motorcycle = MotorcycleTestModels.MotorcycleDefault();
            var command = CommandMotorcycleTestModels.AddMotorcycleCommandDefault();

            _repositoryMock.Setup(repo => repo.GetByLicensePlate("ABC123")).ReturnsAsync((Motorcycle)null);
            _repositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Motorcycle>())).ReturnsAsync(motorcycle);

            //Act
            var result = await _handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.Success);
            Assert.Equivalent(new BaseResult(result: motorcycle), result);
            _repositoryMock.Verify(repo => repo.GetByLicensePlate("ABC123"), Times.Once);
            _repositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Motorcycle>()), Times.Once);
        }

        [Fact]
        public async Task Handle_With_Duplicate_License_Plate_Returns_Motorcycle_Result_With_Error()
        {
            //Arrange
            var command = CommandMotorcycleTestModels.AddMotorcycleCommandDefault();
            _repositoryMock.Setup(repo => repo.GetByLicensePlate("ABC123")).ReturnsAsync(MotorcycleTestModels.MotorcycleDefault());

            //Act
            var result = await _handler.Handle(command, CancellationToken.None);


            //Assert
            Assert.False(result.Success);
            Assert.Contains("ABC123", result.Message);
            _repositoryMock.Verify(repo => repo.GetByLicensePlate("ABC123"), Times.Once);
            _repositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Motorcycle>()), Times.Never);
        }
    }
}