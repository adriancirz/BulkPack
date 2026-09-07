using ERP_IT13.Domain.Entities;

namespace ERP_IT13.Infrastructure.Services
{
    public static class SeedData
    {
        public static async Task InitializeAsync(ERPDbContext db, IAuthService auth)
        {
            await db.Database.EnsureCreatedAsync();

            if (!db.Users.Any())
            {
                var admin = new User
                {
                    Username = "admin",
                    PasswordHash = auth.HashPassword("admin123"),
                    Role = "Admin",
                    IsActive = true
                };

                var staff = new User
                {
                    Username = "staff",
                    PasswordHash = auth.HashPassword("staff123"),
                    Role = "Staff",
                    IsActive = true
                };

                db.Users.AddRange(admin, staff);
            }

            if (!db.Categories.Any())
            {
                var cat = new Category { Name = "General" };
                db.Categories.Add(cat);
                db.Products.Add(new Product
                {
                    Name = "Sample Product",
                    SKU = "SKU-001",
                    Category = cat,
                    UnitPrice = 10.0m,
                    StockQuantity = 100
                });
            }

            if (!db.Customers.Any())
            {
                db.Customers.Add(new Customer { Name = "Walk-in Customer" });
            }

            await db.SaveChangesAsync();
        }
    }
}
