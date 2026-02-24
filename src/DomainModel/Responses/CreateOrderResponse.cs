namespace TestClone.DomainModel.Responses
{
    /// <summary>
    /// Response model for a created product order.
    /// </summary>
    public class CreateOrderResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier for the order.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the name of the product that was ordered.
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the quantity of the product ordered.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the current status of the order (e.g., "Pending", "Confirmed").
        /// </summary>
        public string Status { get; set; } = string.Empty;
    }
}