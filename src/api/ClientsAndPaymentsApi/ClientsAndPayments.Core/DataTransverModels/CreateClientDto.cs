using System.ComponentModel.DataAnnotations;

namespace ClientsAndPayments.Core.DataTransverModels
{
    public class CreateClientDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
