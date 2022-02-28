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
                },
                new Category
                {
                    Name = "Indian",
                    ParentId = 3
                },
                new Category
                {
                    Name = "Mexican",
                    ParentId = 3
                },
                new Category
                {
                    Name = "Chinese",
                    ParentId = 3
                },
                new Category
                {
                    Name = "Thai",
                    ParentId = 3
                },
                new Category
                {
                    Name = "Non-alcoholic",
                    ParentId = 5
                },
                new Category
                {
                    Name = "Alcohol",
                    ParentId = 5
                },
            };
    }
}
