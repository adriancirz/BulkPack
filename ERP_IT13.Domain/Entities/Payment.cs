using System.ComponentModel.DataAnnotations;

namespace ERP_IT13.Domain.Entities
{
    public class Payment
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

        public decimal Amount { get; set; }

        [MaxLength(100)]
        public string Method { get; set; } = "Cash"; // Cash, Card, Transfer
    }
}


