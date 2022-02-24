using MentorMate.Restaurant.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MentorMate.Restaurant.Data.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public ProductType Type { get; set; }
        [Required]
        public string? Name { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
