using Moq;
using RentMotorcycle.Application.Base;
using RentMotorcycle.Application.Deliverymans.Services;
using RentMotorcycle.Application.RentalMotorcycles.CommandHandlers.RentalMotorcycles;
using RentMotorcycle.Application.RentalMotorcycles.Services;
using RentMotorcycle.Data.DeliveryManAggregate;
using RentMotorcycle.Domain.RentalMotorcycleAggregate;
using RentMotorcycle.Domain.RentalPlansAggregate;

namespace RentMotorcycle.Application.Tests.RentalMotorcycles
{
    public class AddRentalMotorcycleCommandHandlerTest
    {
        private readonly AddRentalMotorcycleCommandHandler _handler;
        private readonly Mock<IRentalMotorcycleService> _mockRentalMotorcycleService;
        private readonly Mock<IRentalPlanRepository> _mockRentalPlanRepository;
        private readonly Mock<IDeliverymanService> _mockDeliverymanService;

        public AddRentalMotorcycleCommandHandlerTest()
        {
            _mockRentalMotorcycleService = new Mock<IRentalMotorcycleService>();
            _mockRentalPlanRepository = new Mock<IRentalPlanRepository>();
            _mockDeliverymanService = new Mock<IDeliverymanService>();

            _handler = new AddRentalMotorcycleCommandHandler(
                _mockRentalMotorcycleService.Object,
                _mockRentalPlanRepository.Object,
                _mockDeliverymanService.Object);
        }

        [Fact]
        public async Task Handle_With_RentalPlan_Not_Exists_Returns_Result_With_Error()
        {
            //Arrange
            var deliverymanId = Guid.NewGuid();
            var rentalPlan = new RentalPlan(7, 15, DateTime.SpecifyKind(Convert.ToDateTime("2024-04-11"), DateTimeKind.Utc));
            var rentalMotorcycleCommand = RentalMotorcycleTestModels.RentalMotorcycleDefault(
                deliverymanId,
                rentalPlan);

            _mockRentalPlanRepository.Setup(repo => repo.GetByIdAsync(rentalPlan.Id)).ReturnsAsync((RentalPlan)null);

            //Act
            var result = await _handler.Handle(rentalMotorcycleCommand, CancellationToken.None);

            //Assert
            Assert.False(result.Success);
            Assert.Equivalent(new BaseResult(false, message: "O Plano informando não foi encontrado no sistema!!"), result);

            _mockRentalPlanRepository.Verify(repo => repo.GetByIdAsync(rentalPlan.Id), Times.Once);
            _mockDeliverymanService.Verify(service => service.ValidateDeliverymanForRentMotorcycle(
                deliverymanId), Times.Never);
            _mockRentalMotorcycleService.Verify(service => service.AddRentalMotorcycle(rentalMotorcycleCommand, It.IsAny<int>()), 
                Times.Never);
        }

        [Fact]
        public async Task Handle_With_Validate_Deliveryman_For_Rent_Motorcycle_False_Returns_Result_With_Error()
        {
            //Arrange
            var deliverymanId = Guid.NewGuid();
            var rentalPlan = new RentalPlan(7, 15, DateTime.SpecifyKind(Convert.ToDateTime("2024-04-11"), DateTimeKind.Utc));
            var rentalMotorcycleCommand = RentalMotorcycleTestModels.RentalMotorcycleDefault(
                deliverymanId,
                rentalPlan);

            _mockRentalPlanRepository.Setup(repo => repo.GetByIdAsync(rentalPlan.Id)).ReturnsAsync(rentalPlan);
            _mockDeliverymanService.Setup(service => service.ValidateDeliverymanForRentMotorcycle(deliverymanId))
                .ReturnsAsync(new BaseResult(false, It.IsAny<string>()));

            //Act
            var result = await _handler.Handle(rentalMotorcycleCommand, CancellationToken.None);

            //Assert
            Assert.False(result.Success);
            Assert.Equivalent(new BaseResult(false, It.IsAny<string>()), result);

            _mockRentalPlanRepository.Verify(repo => repo.GetByIdAsync(rentalPlan.Id), Times.Once);
            _mockDeliverymanService.Verify(service => service.ValidateDeliverymanForRentMotorcycle(
                deliverymanId), Times.Once);
            _mockRentalMotorcycleService.Verify(service => service.AddRentalMotorcycle(rentalMotorcycleCommand, It.IsAny<int>()),
                Times.Never);
        }
    }
}
