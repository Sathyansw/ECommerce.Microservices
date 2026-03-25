using ECommerce.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task AddAsync(OrderHeader order);
        Task<List<OrderHeader>> GetAllAsync(); 

        //Task<List<OrderHeader>> GetOrdersByUserIdAsync(string userId);
    }
}
