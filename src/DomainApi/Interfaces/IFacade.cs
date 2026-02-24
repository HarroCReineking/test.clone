using Playground.DomainModel.Requests;
using Playground.DomainModel.Responses;

namespace Playground.DomainApi.Interfaces
{
    /// <summary>
    /// Defines the contract for facade operations in the playground API.
    /// </summary>
    public interface IFacade
    {
        /// <summary>
        /// Performs a test operation.
        /// </summary>
        /// <returns>A task that returns a string result.</returns>
        Task<string> TestOperation();

        /// <summary>
        /// Creates a new product order based on the provided request.
        /// </summary>
        /// <param name="request">The order creation request containing product name and quantity.</param>
        /// <returns>A task that returns the created order response with order ID and status.</returns>
        Task<CreateOrderResponse> CreateOrder(CreateOrderRequest request);
    }
}