using MentorMate.Restaurant.Domain.Consts;
using System.ComponentModel.DataAnnotations;

namespace MentorMate.Restaurant.Domain.Models.Products
{
    public class CreateProductModel
    {
        [Required(ErrorMessage = Messages.ProductNameRequired)]
        [MaxLength(100, ErrorMessage = Messages.ProductNameLength)]
        public string Name { get; set; }
        [Required(ErrorMessage = Messages.ProductPriceRequired)]
        [Range(0.01, 10000.00, ErrorMessage = Messages.ProductPriceRange)]
        public decimal Price { get; set; }
        [Required(ErrorMessage = Messages.ProductCategoryRequired)]
        public int CategoryId { get; set; }
    }
}
