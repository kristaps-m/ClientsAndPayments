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
    }
}
