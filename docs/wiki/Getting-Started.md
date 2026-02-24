# Getting Started

This page walks you through everything you need to build, run, and test the TestClone API on your local machine.

## Prerequisites

| Requirement | Minimum Version | Notes |
|-------------|-----------------|-------|
| .NET SDK | 10.0 | Pinned via `global.json`; install from [dot.net](https://dotnet.microsoft.com/download) |
| Git | Any recent | For cloning the repository |
| IDE (optional) | VS 2022 / Rider / VS Code | `.vscode/` settings are included |

> **Tip:** Run `dotnet --version` to confirm the correct SDK is active. The repository includes a `global.json` that pins the SDK version automatically.

## Clone the Repository

```bash
git clone https://github.com/HarroCReineking/test.clone.git
cd test.clone
```

## Restore Dependencies

NuGet packages are managed centrally in `Directory.Packages.props`. Restore them with:

```bash
dotnet restore
```

## Build the Solution

```bash
dotnet build
```

All warnings are treated as errors (`Directory.Build.props`), so a clean build with no output means everything is in order.

## Run the API

```bash
dotnet run --project src/WebApi
```

The API starts on `https://localhost:5260` by default. Open Swagger UI in your browser to explore and call the available endpoints:

```
https://localhost:5260/swagger
```

## Run the Tests

Execute all unit tests across both test projects:

```bash
dotnet test
```

To run tests for a specific project:

```bash
# Presentation layer tests
dotnet test src/WebApi.UnitTests

# Business logic layer tests
dotnet test src/DomainApi.UnitTests
```

## Project Configuration

| File | Purpose |
|------|---------|
| `src/WebApi/appsettings.json` | Base application settings |
| `src/WebApi/appsettings.Development.json` | Development-environment overrides |
| `global.json` | Pinned .NET SDK version |
| `Directory.Build.props` | Shared MSBuild properties (nullable, warnings-as-errors) |
| `Directory.Packages.props` | Centralised NuGet package versions |

## Environment-Specific Settings

The ASP.NET Core configuration system loads settings in this order (later entries override earlier ones):

1. `appsettings.json`
2. `appsettings.{Environment}.json` (e.g. `appsettings.Development.json`)
3. Environment variables
4. Command-line arguments

Set the active environment via the `ASPNETCORE_ENVIRONMENT` variable:

```bash
# PowerShell
$env:ASPNETCORE_ENVIRONMENT = "Development"

# Bash / zsh
export ASPNETCORE_ENVIRONMENT=Development
```

## Next Steps

- [API Reference](API-Reference.md) — explore the available endpoints.
- [Development Guide](Development-Guide.md) — learn coding standards and how to contribute.
- [Architecture Overview](../architecture.md) — understand how the layers fit together.
