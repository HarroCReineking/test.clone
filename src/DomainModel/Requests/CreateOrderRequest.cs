namespace Playground.DomainModel.Requests
{
    /// <summary>
    /// Request model for creating a product order.
    /// </summary>
    public class CreateOrderRequest
    {
        /// <summary>
        /// Gets or sets the name of the product being ordered.
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the quantity of the product to order.
        /// </summary>
        public int Quantity { get; set; }
    }
}