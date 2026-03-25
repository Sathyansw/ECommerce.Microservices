using ECommerce.Cart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Cart.Application.Interfaces
{
    public interface ICartRepository
    {
        Task<ShoppingCart?> GetCartByUserIdAsync(string userId);

        Task AddCartAsync(ShoppingCart cart);

        Task SaveChangesAsync();

       
    }
}
