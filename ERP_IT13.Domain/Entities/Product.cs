using System.ComponentModel.DataAnnotations;

namespace ERP_IT13.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? SKU { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        public Category? Category { get; set; }

        public decimal UnitPrice { get; set; }

        public int StockQuantity { get; set; }
    }
}


