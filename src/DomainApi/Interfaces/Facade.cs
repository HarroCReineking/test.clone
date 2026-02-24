using TestClone.DomainModel.Requests;
using TestClone.DomainModel.Responses;

namespace TestClone.DomainApi.Interfaces
{
    /// <summary>
    /// Implements facade operations for the TestClone API.
    /// </summary>
    public class Facade : IFacade
    {
        /// <summary>
        /// Performs a test operation and returns a greeting message.
        /// </summary>
        /// <returns>A task that returns a greeting string.</returns>
        public Task<string> TestOperation()
        {
            return Task.FromResult("Hello from the Facade!");
        }

        /// <summary>
        /// Creates a new product order based on the provided request.
        /// </summary>
        /// <param name="request">The order creation request.</param>
        /// <returns>A task that returns the created order response.</returns>
        public Task<CreateOrderResponse> CreateOrder(CreateOrderRequest request)
        {
            var response = new CreateOrderResponse
            {
                OrderId = Random.Shared.Next(1000, 9999),
                ProductName = request.ProductName,
                Quantity = request.Quantity,
                Status = "Pending",
            };

            return Task.FromResult(response);
        }
    }
}