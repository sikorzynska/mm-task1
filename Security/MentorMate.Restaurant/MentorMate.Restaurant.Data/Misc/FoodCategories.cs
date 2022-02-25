using MentorMate.Restaurant.Data.Entities;

namespace MentorMate.Restaurant.Data.Misc
{
    public static class FoodCategories
    {
        public static ICollection<Category> GetCategories() =>
            new List<Category>
            {
                new Category
                {
                    Name = "Appetizer"
                },
                new Category
                {
                    Name = "Breakfast"
                },
                new Category
                {
                    Name = "Main Menu"
                },
                new Category
                {
                    Name = "Dessert"
                },
                new Category
                {
                    Name = "Beverage"
                }
            };
    }
}
