using Playground.DomainApi.Interfaces;
using Playground.DomainModel.Requests;
using Playground.DomainModel.Responses;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace Playground.WebApi.UnitTests
{
    public class PlaygroundControllerTests
    {
        private readonly Mock<IFacade> _facade;
        private readonly PlaygroundController _controller;

        public PlaygroundControllerTests()
        {
            _facade = new Mock<IFacade>();
            _controller = new PlaygroundController(_facade.Object);
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
