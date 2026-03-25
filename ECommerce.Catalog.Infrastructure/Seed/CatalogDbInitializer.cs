using ECommerce.Catalog.Domain.Entities;
using ECommerce.Catalog.Infrastructure.Persistence;

namespace ECommerce.Catalog.Infrastructure.Seed
{
    public static class CatalogDbInitializer
    {
        public static async Task SeedAsync(CatalogDbContext context)
        {
            // Get category from database
            var category = context.Categories
                .FirstOrDefault(c => c.Name == "Electronics");

            if (category == null)
            {
                throw new Exception("Category 'Electronics' not found in database");
            }

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Laptop",
                        Description = "Gaming Laptop",
                        Price = 1200,
                        StockQuantity = 10,
                        ImageUrl = "https://example.com/laptop.jpg",
                        CategoryId = category.Id   // ← IMPORTANT
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Mobile",
                        Description = "Smartphone",
                        Price = 600,
                        StockQuantity = 25,
                        ImageUrl = "https://example.com/mobile.jpg",
                        CategoryId = category.Id   // ← SAME CATEGORY
                    }
                );

                await context.SaveChangesAsync();
            }
        }
    }
}