using ECommerce.Cart.Application.DTOs;
using ECommerce.Cart.Application.Features.Cart.Queries;
using ECommerce.Cart.Application.Interfaces;

using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Cart.Application.Features.Cart.Queries
{
    public class GetCartQueryHandler : IRequestHandler<GetCartQuery, CartDto>
    {
        private readonly ICartDbContext _repository;
        private readonly IHttpClientFactory _httpClientFactory;

        public GetCartQueryHandler(ICartDbContext repository, IHttpClientFactory httpClientFactory)
        {
            _repository = repository;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<CartDto> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            var cart = await _repository.ShoppingCarts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserId == request.UserId);

            if (cart == null)
                return null;

            var productClient = _httpClientFactory.CreateClient("ProductService");

            var items = new List<CartItemDto>();

            foreach (var item in cart.Items)
            {
                var response = await productClient.GetAsync($"api/products/{item.ProductId}");
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Product service call failed");
                }
                var product = await response.Content.ReadFromJsonAsync<ProductDto>();

                items.Add(new CartItemDto
                {
                    ProductId = item.ProductId,
                    ProductName = product.Name,
                    Quantity = item.Quantity,
                    Price = item.Price
                });
            }

            return new CartDto
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = cart.Items.Select(item => new CartItemDto
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price
                }).ToList()
            };
        }
    }
}
