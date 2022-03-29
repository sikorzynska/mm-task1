namespace MentorMate.Restaurant.Domain.Models.Categories
{
    public class GeneralCategoryModel
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? ParentId { get; set; }
        public IEnumerable<GeneralCategoryModel> Subcategories { get; set; }
    }
}
