using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Cart.Domain.Entities
{
    public class ShoppingCartItem
    {
        public Guid Id { get; set; }

        public Guid CartId { get; set; }   // FK
        public ShoppingCart Cart { get; set; } // Navigation

        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
