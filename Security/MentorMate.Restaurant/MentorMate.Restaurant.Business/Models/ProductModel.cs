using System.ComponentModel.DataAnnotations;

namespace MentorMate.Restaurant.Business.Models
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
