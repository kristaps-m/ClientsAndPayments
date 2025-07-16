using ClientsAndPayments.Core.Models;

namespace ClientsAndPayments.Core.DataTransverModels
{
    public class ClientDetailsAndPayments: Client
    {
        public ICollection<PaymentDto> Payments { get; set; } = new List<PaymentDto>();
    }
}
