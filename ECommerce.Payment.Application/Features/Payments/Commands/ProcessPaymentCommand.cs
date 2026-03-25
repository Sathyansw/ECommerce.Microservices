using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Payment.Application.Features.Payments.Commands
{
    public class ProcessPaymentCommand : IRequest<Guid>
    {
        public Guid OrderId { get; set; }

        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; }
    }
}
