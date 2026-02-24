using Microsoft.AspNetCore.Mvc;
using Playground.DomainApi.Interfaces;
using Playground.DomainModel.Requests;
using Playground.DomainModel.Responses;

namespace Playground.WebApi
{
    /// <summary>
    /// Controller for playground API operations.
    /// </summary>
    [ApiController]
    public class PlaygroundController(IFacade facade) : ControllerBase
    {
        /// <summary>
        /// Executes the test operation and returns the result.
        /// </summary>
        /// <returns>An action result containing the test operation response.</returns>
        [HttpGet]
        [Route("TestOperation")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTestOperation()
        {
            return Ok(await facade.TestOperation());
        }

        /// <summary>
        /// Creates a new product order based on the provided request.
        /// </summary>
        /// <param name="request">The order creation request.</param>
        /// <returns>An action result containing the created order response.</returns>
        [HttpPost]
        [Route("CreateOrder")]
        [ProducesResponseType(typeof(CreateOrderResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> PostCreateOrder(CreateOrderRequest request)
        {
            var response = await facade.CreateOrder(request);
            return Ok(response);
        }
    }
}