using System.ComponentModel.DataAnnotations;

namespace ERP_IT13.Domain.Entities
{
    public class Invoice
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime InvoiceDate { get; set; } = DateTime.UtcNow;

        [Required]
        public Guid CustomerId { get; set; }

        public Customer? Customer { get; set; }

        public ICollection<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();

        public decimal TotalAmount { get; set; }

        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }

    public class InvoiceItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }

        [Required]
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal LineTotal { get; set; }
    }
}


