namespace ClientsAndPayments.Core.DataTransverModels
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public DateTime PaidAt { get; set; }
        public string Note { get; set; } = string.Empty;
    }
}
