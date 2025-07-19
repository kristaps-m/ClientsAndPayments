namespace SaasClientsPaymentTracker.Models
{
    public class ReturnClientDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime RegistredAt { get; set; }
        public decimal TotalPaid { get; set; }
    }
}
