# ERP_IT13 - Run Guide (VS2022 / .NET 8)

## Prerequisites
- Visual Studio 2022 (17.8+) with .NET desktop dev workload
- .NET 8 SDK
- SQL Server (LocalDB or Developer) and SQL Server Management Studio (optional)

## Configure Database
1. Open `ERP_IT13.App/appsettings.json` and set `DefaultConnection` to your SQL Server instance, e.g.
   - LocalDB: `Server=(localdb)\\MSSQLLocalDB;Database=ERP_IT13;Trusted_Connection=True;` (add `TrustServerCertificate=True` if needed)
2. First run will create the database and seed admin/staff users.
   - Admin: `admin` / `admin123`
   - Staff: `staff` / `staff123`

## Run in Visual Studio
1. Open `ERP_IT13.sln` in VS2022.
2. Set `ERP_IT13.App` as Startup Project.
3. Press F5.

## Run via CLI
```bash
cd ERP_IT13.App
 dotnet run
```

## Project Structure
- `ERP_IT13.Domain`: Entities
- `ERP_IT13.Infrastructure`: EF Core `ERPDbContext`, services (auth, seed)
- `ERP_IT13.App`: WPF UI (MVVM), DI Host, Material Design

## Migrations (optional)
If you prefer migrations instead of EnsureCreated:
```bash
cd ERP_IT13.Infrastructure
 dotnet tool install --global dotnet-ef
 dotnet ef migrations add InitialCreate -s ..\ERP_IT13.App\ERP_IT13.App.csproj
 dotnet ef database update -s ..\ERP_IT13.App\ERP_IT13.App.csproj
```

## Next Steps
- Implement CRUD views for Users, Inventory, Sales, and Reports under `ERP_IT13.App/Views` with corresponding ViewModels.
- Add role-based navigation (Admin vs Staff) in the shell.
