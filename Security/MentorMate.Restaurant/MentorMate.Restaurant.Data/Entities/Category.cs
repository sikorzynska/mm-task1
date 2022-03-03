using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MentorMate.Restaurant.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string? Name { get; set; }
        public int? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public virtual Category? Parent { get; set; }
        public virtual ICollection<Category> Children { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
