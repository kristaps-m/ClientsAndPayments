using System.ComponentModel.DataAnnotations;

namespace SaasClientsPaymentTracker.Models
{
    public class PaymentModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int ClientId {get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string Currency {  get; set;} = string.Empty;
        [Required]
        public DateTime PaidAt { get; set;}
        [StringLength(120)]
        public string Note { get; set;} = string.Empty;
    }
}
