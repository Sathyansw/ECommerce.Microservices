using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Application.Services;
using ECommerce.Order.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Features.Orders.Commands
{
    public class CreateOrderCommandHandler
        : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly ICatalogService _catalogService;
        private readonly IOrderRepository _repository;

        public CreateOrderCommandHandler(
            ICatalogService catalogService,
            IOrderRepository repository)
        {
            _catalogService = catalogService;
            _repository = repository;
        }

        public async Task<Guid> Handle(
            CreateOrderCommand request,
            CancellationToken cancellationToken)
        {
            var order = new OrderHeader
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                OrderDate = DateTime.UtcNow,
                Items = new List<OrderItem>()
            };

            decimal totalAmount = 0;

            foreach (var item in request.Items)
            {
                // Validate product from Catalog Service
                var product = await _catalogService.GetProduct(item.ProductId);

                if (product == null)
                    throw new Exception($"Invalid ProductId: {item.ProductId}");

                var orderItem = new OrderItem
                {
                    ProductId = product.Id,
                    Quantity = item.Quantity,

                    // Always take latest price from Catalog Service
                    Price = product.Price,

                    OrderHeaderId = order.Id
                };

                totalAmount += orderItem.Price * orderItem.Quantity;

                order.Items.Add(orderItem);
            }

            // Assign calculated total
            order.TotalAmount = totalAmount;

            await _repository.AddAsync(order);

            return order.Id;
        }
    }
}
