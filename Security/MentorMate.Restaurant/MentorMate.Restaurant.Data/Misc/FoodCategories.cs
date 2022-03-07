using MentorMate.Restaurant.Data.Entities;

namespace MentorMate.Restaurant.Data.Misc
{
    public static class FoodCategories
    {
        private static List<Category> Categories = new List<Category>();

        public static ICollection<Category> GetCategories()
        {
            Categories.AddRange(Main());
            Categories.AddRange(MainMenu());
            Categories.AddRange(Mexican());
            Categories.AddRange(Beverage());
            Categories.AddRange(Alcohol());
            Categories.AddRange(NonAlcoholic());
            Categories.AddRange(Dessert());

            var result = Categories.ToList();

            return result;
        }

        public static ICollection<Category> Main() =>
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
            };

        public static ICollection<Category> MainMenu() =>
            new List<Category>
            {
                new Category
                {
                    Name = "Indian",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Main Menu").Id
                },
                new Category
                {
                    Name = "Mexican",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Main Menu").Id
                },
                new Category
                {
                    Name = "Chinese",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Main Menu").Id
                },
                new Category
                {
                    Name = "Thai",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Main Menu").Id
                },
            };

        public static ICollection<Category> Mexican() =>
            new List<Category>
            {
                new Category
                {
                    Name = "Tacos",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Mexican").Id
                },
                new Category
                {
                    Name = "Burritos",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Mexican").Id
                },
            };

        public static ICollection<Category> Beverage() =>
            new List<Category>
            {
                new Category
                {
                    Name = "Non-alcoholic",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Beverage").Id,
                },
                new Category
                {
                    Name = "Alcohol",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Beverage").Id,
                },
            };

        public static ICollection<Category> Alcohol() =>
            new List<Category>
            {
                new Category
                {
                    Name = "Base liquor",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Alcohol").Id,
                },
                new Category
                {
                    Name = "Liqueur",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Alcohol").Id,
                },
                new Category
                {
                    Name = "Wine",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Alcohol").Id,
                },
                new Category
                {
                    Name = "Beer",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Alcohol").Id,
                },
            };

        public static ICollection<Category> NonAlcoholic() =>
            new List<Category>
            {
                new Category
                {
                    Name = "Mocktail",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Non-alcoholic").Id,
                },
                new Category
                {
                    Name = "Water",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Non-alcoholic").Id,
                },
                new Category
                {
                    Name = "Squash",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Non-alcoholic").Id,
                },
                new Category
                {
                    Name = "Juice",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Non-alcoholic").Id,
                },
                new Category
                {
                    Name = "Tea",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Non-alcoholic").Id,
                },
                new Category
                {
                    Name = "Coffee",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Non-alcoholic").Id,
                },
            };

        public static ICollection<Category> Dessert() =>
            new List<Category>
            {
                new Category
                {
                    Name = "Cake",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Dessert").Id,
                },
                new Category
                {
                    Name = "Pastries",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Dessert").Id,
                },
                new Category
                {
                    Name = "Frozen",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Dessert").Id,
                },
            };

    }
}
