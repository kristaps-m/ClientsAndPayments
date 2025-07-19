using System.ComponentModel.DataAnnotations;

namespace SaasClientsPaymentTracker.Models
{
    public class CreateClientDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public DateTime RegistredAt { get; set; } = DateTime.UtcNow;
    }
}
