using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Cart.Application.DTOs
{
    public class CartDto
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public List<CartItemDto> Items { get; set; }
    }
}
