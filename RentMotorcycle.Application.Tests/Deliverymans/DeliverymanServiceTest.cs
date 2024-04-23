using Moq;
using RentMotorcycle.Application.Base;
using RentMotorcycle.Application.Deliverymans.Services;
using RentMotorcycle.Data.DeliveryManAggregate;

namespace RentMotorcycle.Application.Tests.Deliverymans
{
    public class DeliverymanServiceTest
    {
        private readonly IDeliverymanService _service;
        private readonly Mock<IDeliverymanRepository> _repositoryMock;

        public DeliverymanServiceTest()
        {
            _repositoryMock = new Mock<IDeliverymanRepository>();
            _service = new DeliverymanService(_repositoryMock.Object);
        }

        [Fact]
        public async Task When_Valid_Deliveryman_For_Rent_Motorcycle_Return_Result_With_Added_Rent()
        {
            //Arrange
            var deliveryman = DeliverymanTestModels.DeliverymanDefault();

            _repositoryMock.Setup(repo => repo.GetByIdAsync(deliveryman.Id)).ReturnsAsync(deliveryman);

            //Act
            var result = await _service.ValidateDeliverymanForRentMotorcycle(deliveryman.Id);

            //Assert
            Assert.True(result.Success);
            Assert.Equivalent(new BaseResult(result: deliveryman), result);

            _repositoryMock.Verify(service => service.GetByIdAsync(deliveryman.Id), Times.Once);
        }

        [Fact]
        public async Task When_Deliveryman_Not_Exists_Return_Result_With_Error()
        {
            //Arrange
            var deliveryman = DeliverymanTestModels.DeliverymanDefault();

            _repositoryMock.Setup(repo => repo.GetByIdAsync(Guid.NewGuid())).ReturnsAsync((Deliveryman)null);

            //Act
            var result = await _service.ValidateDeliverymanForRentMotorcycle(deliveryman.Id);

            //Assert
            Assert.False(result.Success);
            Assert.Equivalent("O Entregador informando não foi encontrado no sistema!!", result.Message);

            _repositoryMock.Verify(service => service.GetByIdAsync(deliveryman.Id), Times.Once);
        }

        [Fact]
        public async Task When_LicenseType_Deliveryman_is_Invalid_Return_Result_With_Error()
        {
            //Arrange
            var deliveryman = DeliverymanTestModels.DeliverymanWithLicenseTypeBDefault();

            _repositoryMock.Setup(repo => repo.GetByIdAsync(deliveryman.Id)).ReturnsAsync(deliveryman);

            //Act
            var result = await _service.ValidateDeliverymanForRentMotorcycle(deliveryman.Id);

            //Assert
            Assert.False(result.Success);
            Assert.Equivalent("O Entregador informando não possuí habilitação para pilotar motos!!", result.Message);

            _repositoryMock.Verify(service => service.GetByIdAsync(deliveryman.Id), Times.Once);
        }
    }
}
