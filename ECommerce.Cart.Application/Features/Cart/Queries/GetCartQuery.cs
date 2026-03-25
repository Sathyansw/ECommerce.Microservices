using ECommerce.Cart.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Cart.Application.Features.Cart.Queries
{

    public class GetCartQuery : IRequest<CartDto>
    {
        public string UserId { get; set; }

        public GetCartQuery(string userId)
        {
            UserId = userId;
        }
    }
}
