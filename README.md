## ASP.NET Core MVC Boilerplate (Clean, Testable, Reusable)

Production-ready starter for ASP.NET Core MVC (.NET 8) aligned with Clean Code and SOLID principles. Includes layered architecture, DI, structured logging, validation, global error handling, security headers, HTTPS enforcement, and an xUnit test project with Moq.

### Tech Stack
- .NET 8, ASP.NET Core MVC
- DI via built-in `IServiceCollection`
- Serilog (console + rolling file)
- FluentValidation + DataAnnotations (server + client)
- AutoMapper (ready to use)
- Cookie Authentication scaffold (placeholder login)
- xUnit + Moq tests

### Project Structure
```
ASP_MVC.sln
ASP_MVC/                      # Web app (net8.0)
  Configurations/             # App settings, DI, Serilog
  Controllers/                # MVC controllers (Base, Home, Items, Account)
  Filters/                    # GlobalException, Logging, HTTPS, Auth, Cache
  Helpers/                    # Utility types (e.g., Result)
  Middlewares/                # Security headers
  Models/                     # Domain/view models (ErrorViewModel)
  Repositories/               # Example repository abstraction & impl
  Services/                   # Example service abstraction & impl
  Validators/                 # FluentValidation validators
  ViewModels/                 # View Models
  Views/                      # Razor views (Items, Account, Shared)
  wwwroot/                    # Static assets
  Program.cs                  # Composition root (DI, filters, middleware)
  appsettings.json            # Logging + AppSettings
  appsettings.Development.json

ASP_MVC.Tests/                # Test project (xUnit + Moq)
```

### Key Design Choices
- Separation of concerns: Controllers -> Services -> Repositories
- DI registration in `Configurations/DependencyInjection.cs`
- Structured logs via Serilog (`appsettings.json`) to console and rolling files under `Logs/`
- Global error handling via `GlobalExceptionFilter` and friendly error view
- Security: `SecurityHeadersMiddleware` + `RequireHttpsPermanentFilter` (enforces HTTPS outside Development)
- Validation: DataAnnotations + FluentValidation (server + client); unobtrusive client scripts included
- Auth: Cookie auth scaffold (`AccountController`) for demo purposes (replace with Identity/OIDC in real apps)

### Prerequisites
- .NET SDK 8.x

### Getting Started
```bash
# Restore
dotnet restore

# Build (solution root)
dotnet build

# Run the web app
dotnet run --project ASP_MVC/ASP_MVC.csproj

# Open in browser
http://localhost:5000
```

### Testing
```bash
dotnet test
```

### Configuration
- `appsettings.json` contains `Serilog` and `AppSettings` (Logging, Security)
- `appsettings.Development.json` increases verbosity for local dev
- Bindings are strongly-typed via `Configurations/AppSettings.cs`

### Logging
- Configured via `Configurations/SerilogConfigurationExtensions.cs`
- Console + rolling file: `Logs/log-.txt` (daily, retention configurable)

### Dependency Injection
- Add your own interfaces/implementations under `Services/` and `Repositories/`
- Register in `Configurations/DependencyInjection.cs`

### Error Handling
- `GlobalExceptionFilter` logs unhandled exceptions and renders `Views/Shared/Error.cshtml`

### Security
- `RequireHttpsPermanentFilter` redirects to HTTPS outside Development
- `SecurityHeadersMiddleware` adds common security headers
- Cookie auth scaffold for demo; replace with Identity or OAuth/OpenID Connect for production

### Publishing to GitHub
```bash
# From repository root
git init
git add .
git commit -m "chore: initialize ASP.NET Core MVC boilerplate"
git branch -M main
git remote add origin https://github.com/<your-org>/<your-repo>.git
git push -u origin main
```

Recommended follow-ups:
- Enable branch protection on `main`
- Add CI (e.g., GitHub Actions) to build and run tests on PRs
- Add code owners and PR templates

### Roadmap (optional)
- Replace demo cookie auth with Identity or OIDC
- Add response caching/ETags and distributed cache
- Add AutoMapper profiles and mapping tests
- Add feature folders if adopting feature-based structure

### License
Add your organization’s license here.


