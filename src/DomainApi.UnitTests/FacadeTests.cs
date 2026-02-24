using TestClone.DomainApi.Interfaces;
using TestClone.DomainModel.Requests;

namespace TestClone.DomainApi.UnitTests
{
    public class FacadeTests
    {
        [Test]
        public async Task TestOperationReturnsExpectedString()
        {
            var facade = new Facade();
            var result = await facade.TestOperation();
            await Assert.That(result).IsEqualTo("Hello from the Facade!");
        }

        [Test]
        public async Task TestOperationReturnsConsistentResults()
        {
            var facade = new Facade();
            var result = await facade.TestOperation();
            Assert.Equals("Hello from the Facade!", result);
        }

        [Test]
        public async Task CreateOrderReturnsResponseWithOrderId()
        {
            // Arrange
            var facade = new Facade();
            var request = new CreateOrderRequest { ProductName = "Widget", Quantity = 5 };

            // Act
            var result = await facade.CreateOrder(request);

            // Assert
            await Assert.That(result.OrderId).IsGreaterThan(0);
            await Assert.That(result.ProductName).IsEqualTo("Widget");
            await Assert.That(result.Quantity).IsEqualTo(5);
            await Assert.That(result.Status).IsEqualTo("Pending");
        }

        [Test]
        public async Task CreateOrderPreservesRequestData()
        {
            // Arrange
            var facade = new Facade();
            var request = new CreateOrderRequest { ProductName = "Gadget", Quantity = 10 };

            // Act
            var result = await facade.CreateOrder(request);

            // Assert
            await Assert.That(result.ProductName).IsEqualTo(request.ProductName);
            await Assert.That(result.Quantity).IsEqualTo(request.Quantity);
        }
    }
}
