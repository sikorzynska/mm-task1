using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MentorMate.Restaurant.Data.Entities
{
    public class Product
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CategoryId { get; set; }
        public Category? Category { get; set; }
        [Required, MaxLength(100)]
        public string? Name { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
