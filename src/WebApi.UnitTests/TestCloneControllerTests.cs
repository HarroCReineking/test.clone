using TestClone.DomainApi.Interfaces;
using TestClone.DomainModel.Requests;
using TestClone.DomainModel.Responses;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace TestClone.WebApi.UnitTests
{
    public class TestCloneControllerTests
    {
        private readonly Mock<IFacade> _facade;
        private readonly TestCloneController _controller;

        public TestCloneControllerTests()
        {
            _facade = new Mock<IFacade>();
            _controller = new TestCloneController(_facade.Object);
        }

        [Test]
        public async Task GetTestOperationReturnsExpectedValue()
        {
            // Arrange
            _facade.Setup(f => f.TestOperation()).ReturnsAsync("Hello from the Facade!");

            // Act
            var result = await _controller.GetTestOperation();

            // Assert
            var okResult = result as OkObjectResult;
            await Assert.That(okResult).IsNotNull();
            await Assert.That(okResult.Value).IsEqualTo("Hello from the Facade!");
        }

        [Test]
        public async Task PostCreateOrderReturnsOkWithResponse()
        {
            // Arrange
            var request = new CreateOrderRequest { ProductName = "Widget", Quantity = 5 };
            var response = new CreateOrderResponse
            {
                OrderId = 1234,
                ProductName = "Widget",
                Quantity = 5,
                Status = "Pending",
            };
            _facade.Setup(f => f.CreateOrder(request)).ReturnsAsync(response);

            // Act
            var result = await _controller.PostCreateOrder(request);

            // Assert
            var okResult = result as OkObjectResult;
            await Assert.That(okResult).IsNotNull();
            await Assert.That(okResult.Value).IsEqualTo(response);
        }
    }

}
