# API Reference

The TestClone API is a RESTful HTTP API documented with **OpenAPI 3.0 / Swagger UI**.

> **Interactive docs:** Start the API (`dotnet run --project src/WebApi`) and open `https://localhost:5260/swagger` to explore and execute endpoints directly in the browser.

## Base URL

```
https://localhost:5260
```

## Endpoints

### GET /TestOperation

Returns a greeting message. Primarily used to verify the API and Facade wiring are working end-to-end.

**Request**

No request body or query parameters required.

```http
GET /TestOperation HTTP/1.1
Host: localhost:5260
```

**Response — 200 OK**

| Field | Type | Description |
|-------|------|-------------|
| *(body)* | `string` | Greeting message from the Facade layer |

```json
"Hello from the Facade!"
```

---

### POST /CreateOrder

Creates a new product order. The order is processed by the `Facade` and assigned a random order ID with an initial status of `"Pending"`.

**Request**

| Field | Type | Required | Description |
|-------|------|----------|-------------|
| `productName` | `string` | ✅ | Name of the product being ordered |
| `quantity` | `integer` | ✅ | Number of units to order |

```http
POST /CreateOrder HTTP/1.1
Host: localhost:5260
Content-Type: application/json

{
  "productName": "Widget A",
  "quantity": 5
}
```

**Response — 200 OK**

| Field | Type | Description |
|-------|------|-------------|
| `orderId` | `integer` | Randomly generated unique order identifier (1000–9998) |
| `productName` | `string` | Echoed product name from the request |
| `quantity` | `integer` | Echoed quantity from the request |
| `status` | `string` | Initial order status — always `"Pending"` |

```json
{
  "orderId": 4271,
  "productName": "Widget A",
  "quantity": 5,
  "status": "Pending"
}
```

---

## Models

### CreateOrderRequest

Defined in `src/DomainModel/Requests/CreateOrderRequest.cs`.

```csharp
public class CreateOrderRequest
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
}
```

### CreateOrderResponse

Defined in `src/DomainModel/Responses/CreateOrderResponse.cs`.

```csharp
public class CreateOrderResponse
{
    public int OrderId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public string Status { get; set; }
}
```

---

## Controller

All endpoints are handled by `TestCloneController` (`src/WebApi/TestCloneController.cs`), which delegates to `IFacade` for business logic. The controller is deliberately thin — it only performs HTTP mapping and delegates work to the Facade layer.

```csharp
[ApiController]
public class TestCloneController(IFacade facade) : ControllerBase
{
    [HttpGet]
    [Route("TestOperation")]
    public async Task<IActionResult> GetTestOperation() { ... }

    [HttpPost]
    [Route("CreateOrder")]
    public async Task<IActionResult> PostCreateOrder(CreateOrderRequest request) { ... }
}
```

---

## Related Documentation

- [Getting Started](Getting-Started.md) — how to run the API locally.
- [Architecture Overview](../architecture.md) — how the layers connect.
