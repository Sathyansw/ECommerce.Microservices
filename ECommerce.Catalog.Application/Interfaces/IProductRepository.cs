using ECommerce.Catalog.Application.DTOs;
using ECommerce.Catalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();

        Task<Product> GetByIdAsync(Guid id);

        Task AddAsync(Product product);
      
        Task<List<ProductDto>> GetProductsWithCategoryAsync();

    }
}
