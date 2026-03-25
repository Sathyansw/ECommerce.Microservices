using ECommerce.Payment.Application.Interfaces;
using ECommerce.Payment.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Payment.Application.Features.Payments.Commands
{
    public class ProcessPaymentCommandHandler : IRequestHandler<ProcessPaymentCommand, Guid>
    {
        private readonly IPaymentRepository _repository;

        public ProcessPaymentCommandHandler(IPaymentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(ProcessPaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = new PaymentProcess
            {
                Id = Guid.NewGuid(),
                OrderId = request.OrderId,
                Amount = request.Amount,
                PaymentMethod = request.PaymentMethod,
                Status = "Completed",
                PaymentDate = DateTime.UtcNow
            };

            await _repository.AddAsync(payment);

            return payment.Id;
        }
    }
}
