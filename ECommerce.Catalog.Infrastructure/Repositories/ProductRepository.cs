using ECommerce.Catalog.Application.DTOs;
using ECommerce.Catalog.Application.Interfaces;
using ECommerce.Catalog.Domain.Entities;
using ECommerce.Catalog.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogDbContext _context;

        public ProductRepository(CatalogDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);

            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductDto>>
        GetProductsWithCategoryAsync()
        {
            return await
                (from product in _context.Products
                 join category in _context.Categories
                 on product.CategoryId equals category.Id

                 select new ProductDto
                 {
                     Id = product.Id,
                     Name = product.Name,
                     Description = product.Description,
                     Price = product.Price,
                     StockQuantity = product.StockQuantity,
                     CategoryId = product.CategoryId,
                     CategoryName = category.Name,
                     ImageUrl = product.ImageUrl
                 }).ToListAsync();
        }
    }
}
