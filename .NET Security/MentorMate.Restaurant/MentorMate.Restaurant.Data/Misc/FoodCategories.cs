using MentorMate.Restaurant.Data.Entities;

namespace MentorMate.Restaurant.Data.Misc
{
    public static class FoodCategories
    {
        private static List<Category> Categories = new List<Category>();

        public static ICollection<Category> GetCategories()
        {
            Categories.AddRange(Main());
            Categories.AddRange(Starter());
            Categories.AddRange(MainCourse());
            Categories.AddRange(FastFood());
            Categories.AddRange(MainDishes());
            Categories.AddRange(Dessert());
            Categories.AddRange(Beverage());
            Categories.AddRange(Alcoholic());
            Categories.AddRange(NonAlcoholic());

            var result = Categories.ToList();

            return result;
        }

        public static ICollection<Category> Main() =>
            new List<Category>
            {
                new Category
                {
                    Name = "Starter"
                },
                new Category
                {
                    Name = "Main Course"
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

        public static ICollection<Category> Starter() =>
            new List<Category>
            {
                new Category
                {
                    Name = "Salad",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Starter").Id
                },
                new Category
                {
                    Name = "Fried",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Starter").Id
                },
            };

        public static ICollection<Category> MainCourse() =>
            new List<Category>
            {
                new Category
                {
                    Name = "Fast food",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Main Course").Id
                },
                new Category
                {
                    Name = "Main dishes",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Main Course").Id
                },
            };

        public static ICollection<Category> FastFood() =>
            new List<Category>
            {
                new Category
                {
                    Name = "Burger",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Fast food").Id,
                },
                new Category
                {
                    Name = "Pizza",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Fast food").Id,
                },
            };

        public static ICollection<Category> MainDishes() =>
            new List<Category>
            {
                new Category
                {
                    Name = "Meat",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Main dishes").Id,
                },
                new Category
                {
                    Name = "Vegetarian",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Main dishes").Id,
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

        public static ICollection<Category> Beverage() =>
            new List<Category>
            {
                new Category
                {
                    Name = "Alcoholic",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Beverage").Id,
                },
                new Category
                {
                    Name = "Non-alcoholic",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Beverage").Id,
                },
            };

        public static ICollection<Category> Alcoholic() =>
            new List<Category>
            {
                new Category
                {
                    Name = "Beer",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Alcoholic").Id,
                },
                new Category
                {
                    Name = "Wine",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Alcoholic").Id,
                },
                new Category
                {
                    Name = "Liquour",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Alcoholic").Id,
                },
            };

        public static ICollection<Category> NonAlcoholic() =>
            new List<Category>
            {
                new Category
                {
                    Name = "Coffee",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Non-alcoholic").Id,
                },
                new Category
                {
                    Name = "Tea",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Non-alcoholic").Id,
                },
                new Category
                {
                    Name = "Juice",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Non-alcoholic").Id,
                },
                new Category
                {
                    Name = "Carbonated drink",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Non-alcoholic").Id,
                },
                new Category
                {
                    Name = "Water",
                    ParentId = Categories.FirstOrDefault(x => x.Name == "Non-alcoholic").Id,
                },
            };

    }
}
