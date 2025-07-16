using System.ComponentModel.DataAnnotations;

namespace ClientsAndPayments.Core.Models
{
    public class Client:Entity
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public DateTime RegistredAt {  get; set; }

        // Navigation property
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
