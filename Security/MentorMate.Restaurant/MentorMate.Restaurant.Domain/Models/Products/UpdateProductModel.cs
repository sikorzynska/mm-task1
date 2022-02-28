using MentorMate.Restaurant.Domain.Consts;
using System.ComponentModel.DataAnnotations;

namespace MentorMate.Restaurant.Domain.Models.Products
{
    public class UpdateProductModel
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(100, ErrorMessage = Messages.ProductNameLength)]
        public string? Name { get; set; }
        [Range(0.01, 10000.00, ErrorMessage = Messages.ProductPriceRange)]
        public decimal? Price { get; set; }
        public int? CategoryId { get; set; }
    }
}
