using ECommerce.Catalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task<bool> ExistsAsync(Guid categoryId);

        Task<Category?> GetByIdAsync(Guid id);

        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByNameAsync(string name);
        Task AddAsync(Category category);
    }
}
