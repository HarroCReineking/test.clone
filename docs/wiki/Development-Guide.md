# Development Guide

This guide covers coding standards, testing conventions, and the contribution workflow for the TestClone project.

## Coding Standards

### Language and Framework Versions

- **C# 14** — use the latest language features (primary constructors, pattern matching, collection expressions, etc.).
- **.NET 10 / ASP.NET Core 10** — target `net10.0` for all projects.

### Naming Conventions

| Construct | Convention | Example |
|-----------|------------|---------|
| Types, methods, public members | PascalCase | `CreateOrder`, `OrderId` |
| Interfaces | `I` prefix + PascalCase | `IFacade` |
| Private fields | `_camelCase` | `_facade` |
| Local variables, parameters | camelCase | `createOrderRequest` |

### Formatting

- File-scoped namespace declarations and single-line `using` directives.
- Insert a blank line before every opening `{` of a control-flow block (`if`, `for`, `foreach`, `using`, `try`, etc.).
- Final `return` statement on its own line.
- Prefer **pattern matching** and **switch expressions** over `if`/`else` chains.
- Use `nameof(...)` instead of string literals when referring to member names.
- Apply formatting rules from `.editorconfig` — the CI pipeline enforces these.

### Null Safety

- All projects have `Nullable` enabled; declare variables as **non-nullable** unless intentionally nullable.
- Check for `null` at public entry points.
- Use `is null` / `is not null` — never `== null` / `!= null`.

### XML Documentation

Every public API surface (classes, interfaces, methods, properties) must have an XML `<summary>` comment. Include `<param>`, `<returns>`, and optionally `<example>` / `<code>` where appropriate.

```csharp
/// <summary>
/// Creates a new product order based on the provided request.
/// </summary>
/// <param name="request">The order creation request containing product name and quantity.</param>
/// <returns>A task that returns the created order response with order ID and status.</returns>
Task<CreateOrderResponse> CreateOrder(CreateOrderRequest request);
```

### Code Quality

- **Warnings treated as errors** (`Directory.Build.props`): all compiler warnings must be resolved before merging.
- Prefer constructor injection for all dependencies; register services in `Program.cs`.
- Keep controllers thin — delegate all business logic to `IFacade`.

## Testing

### Frameworks

| Library | Purpose |
|---------|---------|
| **TUnit** | Unit testing framework |
| **Moq** | Mocking / test-double creation |

### Test Project Layout

| Project | What it tests |
|---------|--------------|
| `src/WebApi.UnitTests` | Controllers (mocked `IFacade`) |
| `src/DomainApi.UnitTests` | `Facade` business logic (no mocking needed) |

### Test Naming Convention

```
ClassNameMethodNameExpectedBehavior
```

Example: `TestCloneControllerGetTestOperationReturnsOkWithFacadeResult`

### Test Structure

Use `// Arrange`, `// Act`, `// Assert` comments to clearly separate the three phases:

```csharp
[Test]
public async Task TestCloneControllerGetTestOperationReturnsOkWithFacadeResult()
{
    // Arrange
    var mockFacade = new Mock<IFacade>();
    mockFacade.Setup(f => f.TestOperation()).ReturnsAsync("Hello from the Facade!");
    var controller = new TestCloneController(mockFacade.Object);

    // Act
    var result = await controller.GetTestOperation();

    // Assert
    var okResult = result as OkObjectResult;
    await Assert.That(okResult).IsNotNull();
    await Assert.That(okResult!.Value).IsEqualTo("Hello from the Facade!");
}
```

### Conventions

- Do **not** use `_` in test method names.
- Do **not** use FluentAssertions — use TUnit's built-in `Assert.That(...)` assertions.
- Do **not** add XML documentation comments to test methods.
- Always cover the critical paths of every new feature.

### Running Tests

```bash
# All tests
dotnet test

# Single test project
dotnet test src/WebApi.UnitTests
dotnet test src/DomainApi.UnitTests
```

## Adding a New Endpoint

1. **DomainModel** — Add request/response DTOs in `src/DomainModel/Requests/` and `src/DomainModel/Responses/`.
2. **DomainApi** — Add the operation signature to `IFacade` and implement it in `Facade`.
3. **WebApi** — Add a new action method to `TestCloneController` (or a new controller if the domain warrants it).
4. **Tests** — Add unit tests for both the controller action (mock `IFacade`) and the `Facade` implementation.

## Contribution Workflow

1. Fork or branch from `main`.
2. Implement your changes following the coding standards above.
3. Ensure `dotnet build` produces **zero warnings**.
4. Ensure `dotnet test` passes with **all tests green**.
5. Open a Pull Request using the provided PR template (`.github/pull_request_template.md`).
6. Address review feedback and update your branch as needed.

## Useful Commands

```bash
# Build (warnings treated as errors)
dotnet build

# Run the API locally
dotnet run --project src/WebApi

# Run all unit tests
dotnet test

# Restore NuGet packages
dotnet restore
```

## Related Documentation

- [Home](Home.md) — project overview and navigation.
- [Getting Started](Getting-Started.md) — first-time setup.
- [API Reference](API-Reference.md) — available endpoints.
- [Architecture Overview](../architecture.md) — layer responsibilities and design patterns.
