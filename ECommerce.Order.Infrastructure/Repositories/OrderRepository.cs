using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using ECommerce.Order.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _context;

        public OrderRepository(OrderDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(OrderHeader order)
        {
            await _context.OrdersHeaders.AddAsync(order);

            await _context.SaveChangesAsync();
        }

        public async Task<List<OrderHeader>> GetAllAsync()
        {
            return await _context.OrdersHeaders.ToListAsync();
        }
    }   
}
