using ECommerce.Payment.Application.Interfaces;
using ECommerce.Payment.Domain.Entities;
using ECommerce.Payment.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Payment.Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentDbContext _context;

        public PaymentRepository(PaymentDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(PaymentProcess payment)
        {
            _context.PaymentProcesss.Add(payment);
            await _context.SaveChangesAsync();
        }

        public async Task<PaymentProcess?> GetByOrderIdAsync(Guid orderId)
        {
            return await _context.PaymentProcesss
                .FirstOrDefaultAsync(p => p.OrderId == orderId);
        }
    }
}
