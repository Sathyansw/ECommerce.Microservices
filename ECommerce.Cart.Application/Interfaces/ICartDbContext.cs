using ECommerce.Cart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Cart.Application.Interfaces
{
    public interface ICartDbContext
    {
        DbSet<ShoppingCart> ShoppingCarts { get; }
        DbSet<ShoppingCartItem> ShoppingCartItems { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
