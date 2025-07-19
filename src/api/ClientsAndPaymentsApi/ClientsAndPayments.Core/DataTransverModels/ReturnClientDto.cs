namespace ClientsAndPayments.Core.DataTransverModels
{
    public class ReturnClientDto: CreateClientDto
    {
        public int Id { get; set; }
        public DateTime RegistredAt { get; set; }
        public decimal TotalPaid { get; set; }
    }
}
