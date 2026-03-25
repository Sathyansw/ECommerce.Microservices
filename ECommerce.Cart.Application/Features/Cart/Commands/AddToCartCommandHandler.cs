using ECommerce.Cart.Application.Interfaces;
using ECommerce.Cart.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Cart.Application.Features.Cart.Commands
{
    public class AddToCartCommandHandler : IRequestHandler<AddToCartCommand, Unit>
    {
        private readonly ICartRepository _repository;

        public AddToCartCommandHandler(ICartRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AddToCartCommand request, CancellationToken cancellationToken)
        {
            // Get cart with items
            var cart = await _repository.GetCartByUserIdAsync(request.UserId);

            if (cart == null)
            {
                cart = new ShoppingCart
                {
                    Id = Guid.NewGuid(),
                    UserId = request.UserId,
                    Items = new List<ShoppingCartItem>()
                };

                await _repository.AddCartAsync(cart);
            }

            var existingItem = cart.Items?
                .FirstOrDefault(x => x.ProductId == request.ProductId);

            if (existingItem != null)
            {
                // Update quantity
                existingItem.Quantity += request.Quantity;
            }
            else
            {
                // Add new item via navigation (BEST WAY)
                cart.Items.Add(new ShoppingCartItem
                {
                    Id = Guid.NewGuid(),
                    CartId = cart.Id,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity,
                    Price = request.Price
                });
            }

            // Save once
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
