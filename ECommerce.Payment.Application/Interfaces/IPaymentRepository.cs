using ECommerce.Payment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Payment.Application.Interfaces
{
    public interface IPaymentRepository
    {
        Task AddAsync(PaymentProcess payment);

        Task<PaymentProcess?> GetByOrderIdAsync(Guid orderId);
    }
}
