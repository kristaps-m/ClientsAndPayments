using System.ComponentModel.DataAnnotations;

namespace ClientsAndPayments.Core.Models
{
    public class Payment: Entity
    {
        [Required]
        public int ClientId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string Currency { get; set; } = string.Empty;
        [Required]
        public DateTime PaidAt { get; set; }
        [StringLength(120)]
        public string Note { get; set; } = string.Empty;
        // Navigation property
        public Client? Client { get; set; }
    }
}
