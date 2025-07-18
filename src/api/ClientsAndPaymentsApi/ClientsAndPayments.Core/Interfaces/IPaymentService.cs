using ClientsAndPayments.Core.DataTransverModels;
using ClientsAndPayments.Core.Models;

namespace ClientsAndPayments.Core.Interfaces
{
    public interface IPaymentService: IEntityService<Payment>
    {
        List<PaymentDto> GetLatest20Payments();
    }
}
