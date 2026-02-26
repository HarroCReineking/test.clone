# TestClone Wiki

Welcome to the **TestClone** wiki! This wiki provides comprehensive documentation for the TestClone API project — a .NET 10 / ASP.NET Core RESTful API that demonstrates clean architecture principles.

## What Is TestClone?

TestClone is a reference implementation of a layered ASP.NET Core API. It serves as an exploration project for:

- **.NET 10** and the latest C# 14 language features.
- **Clean / Layered Architecture** with clear separation of concerns.
- **OpenAPI / Swagger** for interactive API documentation.
- **TUnit + Moq** for modern unit-testing patterns.

## Repository Layout

```
test.clone/
├── src/
│   ├── WebApi/              # Presentation layer — HTTP controllers
│   ├── DomainApi/           # Business logic layer — Facade pattern
│   │   └── Interfaces/      # IFacade contract + Facade implementation
│   ├── DomainModel/         # Domain layer — request/response models
│   │   ├── Requests/        # Inbound request DTOs
│   │   └── Responses/       # Outbound response DTOs
│   ├── WebApi.UnitTests/    # Unit tests for the presentation layer
│   └── DomainApi.UnitTests/ # Unit tests for the business logic layer
├── docs/
│   ├── architecture.md      # Detailed architecture reference
│   └── wiki/                # This wiki
├── .github/                 # Workflows, issue templates, PR template
├── Directory.Build.props    # Shared MSBuild properties (warnings-as-errors, etc.)
├── Directory.Packages.props # Centralized NuGet package versions
├── global.json              # Pinned .NET SDK version
└── test.clone.slnx          # Solution file
```

## Quick Navigation

| Page | Description |
|------|-------------|
| [Getting Started](Getting-Started.md) | Prerequisites, build, run, and test the project locally |
| [API Reference](API-Reference.md) | Available endpoints with request / response details |
| [Development Guide](Development-Guide.md) | Coding standards, testing approach, and contribution workflow |
| [Architecture Overview](../architecture.md) | In-depth layered architecture and design-pattern documentation |

## Technology Stack

| Category | Technology |
|----------|------------|
| Runtime | .NET 10.0 |
| Web framework | ASP.NET Core |
| API docs | OpenAPI 3.0 / Swashbuckle (Swagger UI) |
| Unit testing | TUnit |
| Mocking | Moq |
| Package management | Central Package Management (`Directory.Packages.props`) |

## Key Design Decisions

- **Layered Architecture** — `WebApi` → `DomainApi` → `DomainModel`; dependencies only flow inward.
- **Facade Pattern** — Controllers depend on `IFacade`, keeping them thin and easily testable.
- **Controller-Based API** — Chosen over Minimal APIs for structured class-based organisation.
- **Warnings as Errors** — Enforced in `Directory.Build.props` to maintain a high code-quality bar.
- **Nullable Reference Types** — Enabled project-wide for compile-time null-safety.
