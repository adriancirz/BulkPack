using System.ComponentModel.DataAnnotations;

namespace ERP_IT13.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}


