namespace MentorMate.Restaurant.Domain.Models.Categories
{
    public class GeneralCategoryModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? ParentId { get; set; }
        public IEnumerable<GeneralCategoryModel> Subcategories { get; set; }
    }
}
