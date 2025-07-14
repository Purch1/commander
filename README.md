# Commander API

Commander is a .NET 8 Web API project demonstrating Clean Architecture principles. It provides CRUD operations for managing command entities, using MediatR for CQRS, AutoMapper for mapping, Entity Framework Core for data access, and FluentValidation for input validation.

## Solution Structure

```
Commander.sln
├── Commander.Domain         # Domain models and interfaces
├── Commander.Application   # Application logic, CQRS handlers, validation
├── Commander.Contracts     # DTOs shared between layers
├── Commander.Infrastructure# Data access, EF Core context, repositories
├── Commander.API           # ASP.NET Core Web API
```

### Projects
- **Commander.Domain**: Contains core domain models (`Command`) and repository interfaces.
- **Commander.Application**: Implements MediatR command/query handlers, validation (FluentValidation), and mapping profiles.
- **Commander.Contracts**: Defines DTOs for API requests/responses.
- **Commander.Infrastructure**: Implements EF Core DbContext and repository classes.
- **Commander.API**: ASP.NET Core API controllers, startup configuration, and dependency injection.

## Key Technologies
- **.NET 8**
- **Entity Framework Core**
- **MediatR** (CQRS)
- **AutoMapper**
- **FluentValidation**
- **Swagger/OpenAPI**

## Getting Started

### Prerequisites
- .NET 8 SDK
- SQL Server (localdb or other, see `appsettings.json`)

### Setup & Run
1. **Restore packages**
   ```bash
   dotnet restore
   ```
2. **Apply migrations** (if needed)
   ```bash
   dotnet ef database update --project Commander.Infrastructure
   ```
3. **Run the API**
   ```bash
   dotnet run --project Commander.API
   ```
   The API will be available at `http://localhost:5000` (see `launchSettings.json`).

### API Endpoints
- `GET /api/commands` - List all commands
- `GET /api/commands/{id}` - Get command by ID
- `POST /api/commands` - Create a new command
- `PUT /api/commands/{id}` - Update a command
- `PATCH /api/commands/{id}` - Partially update a command
- `DELETE /api/commands/{id}` - Delete a command

### Validation
- All DTOs are validated using FluentValidation. Validation errors return HTTP 400 with details.

### Architecture Highlights
- **Clean Architecture**: Separation of concerns between Domain, Application, Infrastructure, and API layers.
- **CQRS**: All business logic is handled via MediatR command/query handlers.
- **Validation**: FluentValidation is used for all input DTOs, with custom error messages.
- **Mapping**: AutoMapper is used for DTO/entity conversions.

## Development
- Use Visual Studio or VS Code for development.
- Run and debug using the provided solution file (`Commander.sln`).
- See `RUN_OPTIONS.md` for more ways to run the API.

## Configuration
- Connection string is set in `Commander.API/appsettings.json`.
- Logging is configured in `appsettings.Development.json` and `appsettings.json`.

## Contributing
Pull requests and issues are welcome. Please follow standard .NET and Clean Architecture practices.

## License
MIT License (add your license file if needed)

---
For more details, see the source code and comments in each project folder.
