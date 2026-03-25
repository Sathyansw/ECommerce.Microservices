using ECommerce.Order.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Features.Orders.Commands
{
    //public class CreateOrderCommand : IRequest<Guid>
    //{
    //    public string UserId { get; set; }

    //    public List<CreateOrderItemDto> Items { get; set; }

    //    public decimal TotalAmount { get; set; }
    //}

    public record CreateOrderCommand(
        Guid UserId,
        List<CreateOrderItemDto> Items
    ) : IRequest<Guid>;
}
