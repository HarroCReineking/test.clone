using Microsoft.AspNetCore.Mvc;
using TestClone.DomainApi.Interfaces;
using TestClone.DomainModel.Requests;
using TestClone.DomainModel.Responses;

namespace TestClone.WebApi
{
    /// <summary>
    /// Controller for TestClone API operations.
    /// </summary>
    [ApiController]
    public class TestCloneController(IFacade facade) : ControllerBase
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