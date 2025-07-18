using ClientsAndPayments.Core.DataTransverModels;
using ClientsAndPayments.Core.Interfaces;
using ClientsAndPayments.Core.Models;
using ClientsAndPayments.Data;

namespace ClientsAndPayments.Services
{
    public class PaymentService: EntityService<Payment>, IPaymentService
    {
        public PaymentService(IClientsAndPaymentsDbContext context) : base(context)
        {
            
        }

        public List<PaymentDto> GetLatest20Payments()
        {
            var p = _context.Payments.AsEnumerable()
                .Take(20)
                .OrderByDescending(p => p.PaidAt)
                .Select(p => new PaymentDto
                {
                    Id = p.Id,
                    Amount = p.Amount,
                    Currency = p.Currency,
                    PaidAt = p.PaidAt,
                    Note = p.Note
                })
                .ToList();

            return p;
        }
    }
}
