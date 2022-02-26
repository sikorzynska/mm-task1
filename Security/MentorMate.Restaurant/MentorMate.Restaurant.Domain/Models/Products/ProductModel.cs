using System.ComponentModel.DataAnnotations;

namespace MentorMate.Restaurant.Domain.Models.Products
{
    public class ProductModel
    {
        [Required]
        public string Name { get; set; }
        [Range(1, 5)]
        public int CategoryId { get; set; }
        public decimal Price { get; set; }

    }
}
