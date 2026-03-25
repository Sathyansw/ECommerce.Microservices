using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Services
{
    public interface ICatalogService
    {
        Task<ProductDto?> GetProduct(Guid productId);
    }
}
