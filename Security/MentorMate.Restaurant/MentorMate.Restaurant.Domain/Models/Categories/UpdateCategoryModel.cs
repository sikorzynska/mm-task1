using MentorMate.Restaurant.Domain.Consts;
using System.ComponentModel.DataAnnotations;

namespace MentorMate.Restaurant.Domain.Models.Categories
{
    public class UpdateCategoryModel
    {
        [Required(ErrorMessage = Messages.CategoryNameRequired)]
        [MaxLength(100, ErrorMessage = Messages.CategoryNameLength)]
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}
