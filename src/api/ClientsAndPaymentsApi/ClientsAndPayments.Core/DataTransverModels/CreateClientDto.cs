using System.ComponentModel.DataAnnotations;

namespace ClientsAndPayments.Core.DataTransverModels
{
    public class CreateClientDto
    {
        public string Name { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
