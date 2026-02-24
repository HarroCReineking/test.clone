# playground.api

A playground project for exploring .NET 10 and ASP.NET Core technologies using clean architecture principles.

## Architecture

This project follows a **layered architecture** pattern with clear separation of concerns:

- **WebApi** - Presentation layer (HTTP endpoints, controllers)
- **DomainApi** - Business logic layer (application services, Facade pattern)
- **DomainModel** - Domain layer (entities, value objects)

For detailed architectural documentation, see [Architecture Overview](docs/architecture.md).

## Technology Stack

- .NET 10.0
- ASP.NET Core
- OpenAPI/Swagger
- TUnit (testing)

## Quick Start

1. Build the solution:
   ```powershell
   dotnet build
   ```

2. Run the API:
   ```powershell
   dotnet run --project src/WebApi
   ```

3. Access Swagger UI at: `https://localhost:5260/swagger`

## Documentation

- [Architecture Overview](docs/architecture.md) - Detailed system architecture and design patterns
- [Contributing Guidelines](.github/CONTRIBUTING.md) - Development workflow and standards
- [Copilot Instructions](.github/copilot-instructions.md) - Coding conventions
