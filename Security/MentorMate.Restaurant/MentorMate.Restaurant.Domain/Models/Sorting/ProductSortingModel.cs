using MentorMate.Restaurant.Domain.Models.Sorting.Enums;

namespace MentorMate.Restaurant.Domain.Models.Sorting
{
    public class ProductSortingModel
    {
        public string? Name { get; set; }
        public int? CategoryId { get; set; }
        public OrderByType? OrderBy { get; set; }
        public OrderType? OrderType { get; set; }
    }
}
