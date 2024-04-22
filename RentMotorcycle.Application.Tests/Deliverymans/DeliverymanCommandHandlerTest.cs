using Moq;
using RentMotorcycle.Application.Base;
using RentMotorcycle.Application.Deliverymans;
using RentMotorcycle.Application.Deliverymans.Services;
using RentMotorcycle.Data.DeliveryManAggregate;

namespace RentMotorcycle.Application.Tests.Deliverymans
{
    public class DeliverymanCommandHandlerTest
    {
        private readonly DeliverymanCommandHandler _handler;
        private readonly Mock<IDeliverymanRepository> _repositoryMock;
        private readonly Mock<IDeliverymanService> _serviceMock;

        public DeliverymanCommandHandlerTest()
        {
            _repositoryMock = new Mock<IDeliverymanRepository>();
            _serviceMock = new Mock<IDeliverymanService>();
            _handler = new DeliverymanCommandHandler(
                _repositoryMock.Object,
                _serviceMock.Object);
        }

        [Fact]
        public async Task Handle_With_Valid_Deliveryman_Returns_Motorcycle_Result_With_Added_Deliveryman()
        {
            //Arrange
            var deliveryman = DeliverymanTestModels.DeliverymanDefault();
            var command = CommandDeliverymanTestModels.AddDeliverymanCommandDefault();
            var success = new BaseResult(true, null);

            _serviceMock.Setup(service => 
                service.VerifyDuplicatedDeliveryman(command.Cnpj, command.LicenseDriverNumber))
                    .ReturnsAsync(success);
            _repositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Deliveryman>())).ReturnsAsync(deliveryman);

            //Act
            var result = await _handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.Success);
            Assert.Equivalent(new BaseResult(result: deliveryman), result);

            _serviceMock.Verify(service => service.VerifyDuplicatedDeliveryman(command.Cnpj, command.LicenseDriverNumber), Times.Once);
            _repositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Deliveryman>()), Times.Once);
        }

        [Fact]
        public async Task Handle_With_Duplicate_CNPJ_Returns_Deliveryman_Result_With_Error()
        {
            //Arrange
            var command = CommandDeliverymanTestModels.AddDeliverymanCommandDefault();
            var error = new BaseResult(false, message: $"O entregador com CNPJ '{command.Cnpj}', já está cadastrado no sistema!!");

            _serviceMock.Setup(service =>
                service.VerifyDuplicatedDeliveryman(command.Cnpj, command.LicenseDriverNumber))
                    .ReturnsAsync(error);

            //Act
            var result = await _handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.Success);
            Assert.Contains($"O entregador com CNPJ '{command.Cnpj}', já está cadastrado no sistema!!", result.Message);
            _serviceMock.Verify(service => service.VerifyDuplicatedDeliveryman(command.Cnpj, command.LicenseDriverNumber), Times.Once);
            _repositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Deliveryman>()), Times.Never);
        }

        [Fact]
        public async Task Handle_With_Duplicate_LicenseDriverNumber_Returns_Deliveryman_Result_With_Error()
        {
            //Arrange
            var command = CommandDeliverymanTestModels.AddDeliverymanCommandDefault();
            var error = new BaseResult(false, message: $"O entregador com Número do CNH '{command.LicenseDriverNumber}', já está cadastrado no sistema!!");

            _serviceMock.Setup(service =>
                service.VerifyDuplicatedDeliveryman(command.Cnpj, command.LicenseDriverNumber))
                    .ReturnsAsync(error);

            //Act
            var result = await _handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.Success);
            Assert.Contains($"O entregador com Número do CNH '{command.LicenseDriverNumber}', já está cadastrado no sistema!!", result.Message);
            _serviceMock.Verify(service => service.VerifyDuplicatedDeliveryman(command.Cnpj, command.LicenseDriverNumber), Times.Once);
            _repositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Deliveryman>()), Times.Never);
        }
    }
}
