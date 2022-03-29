using MentorMate.Restaurant.Data.Entities;

namespace MentorMate.Restaurant.Data.Misc
{
    public static class FoodMenu
    {
        public static ICollection<Product> GetProducts(Dictionary<string, string> categoryDictionary) =>
            new List<Product>
            {
                new Product
                {
                    CategoryId = categoryDictionary["Salad"],
                    Name = "Ceasar Salad",
                    Description = "Description placeholder",
                    Price = 5.99m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Salad"],
                    Name = "Greek Salad",
                    Description = "Description placeholder",
                    Price = 6.65m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Salad"],
                    Name = "Caprese Salad",
                    Description = "Description placeholder",
                    Price = 4.20m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Fried"],
                    Name = "Fries",
                    Description = "Description placeholder",
                    Price = 2.50m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Fried"],
                    Name = "Onion Rings",
                    Description = "Description placeholder",
                    Price = 2.50m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Fried"],
                    Description = "Description placeholder",
                    Name = "Fried Mozzarella Sticks",
                    Price = 3.50m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Burger"],
                    Name = "Pork Burger",
                    Description = "Description placeholder",
                    Price = 5
                },
                new Product
                {
                    CategoryId = categoryDictionary["Burger"],
                    Description = "Description placeholder",
                    Name = "Veggie Burger",
                    Price = 4.10m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Burger"],
                    Name = "Chicken Burger",
                    Description = "Description placeholder",
                    Price = 5.35m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Pizza"],
                    Name = "Vegeterian Pizza",
                    Description = "Description placeholder",
                    Price = 4.35m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Pizza"],
                    Name = "Pepperoni Pizza",
                    Description = "Description placeholder",
                    Price = 3.10m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Pizza"],
                    Name = "Neapolitan Pizza",
                    Description = "Description placeholder",
                    Price = 8.85m,
                },
                new Product
                {
                    CategoryId = categoryDictionary["Meat"],
                    Name = "Lasagna",
                    Description = "Description placeholder",
                    Price = 7.85m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Meat"],
                    Name = "Meatloaf",
                    Description = "Description placeholder",
                    Price = 4.10m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Meat"],
                    Name = "Beef Steak",
                    Description = "Description placeholder",
                    Price = 2.35m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Vegetarian"],
                    Name = "Extra Vegetable Fried Rice",
                    Description = "Description placeholder",
                    Price = 2.35m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Vegetarian"],
                    Name = "Crispy Baked Falafel",
                    Description = "Description placeholder",
                    Price = 3.90m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Vegetarian"],
                    Name = "Best Lentil Soup",
                    Description = "Description placeholder",
                    Price = 6.05m,
                },
                new Product
                {
                    CategoryId = categoryDictionary["Cake"],
                    Name = "Chocolate Cake",
                    Description = "Description placeholder",
                    Price = 2.85m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Cake"],
                    Name = "Red Velvet Cake",
                    Description = "Description placeholder",
                    Price = 2.90m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Cake"],
                    Name = "Cheesecake",
                    Description = "Description placeholder",
                    Price = 2.15m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Pastries"],
                    Name = "Apple pie",
                    Description = "Description placeholder",
                    Price = 1.35m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Pastries"],
                    Name = "Pumpkin pie",
                    Description = "Description placeholder",
                    Price = 1.60m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Pastries"],
                    Name = "Giant chocolate chip cookies",
                    Description = "Description placeholder",
                    Price = 2.05m,
                },
                new Product
                {
                    CategoryId = categoryDictionary["Pastries"],
                    Name = "Banana split",
                    Description = "Description placeholder",
                    Price = 3.85m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Cake"],
                    Name = "Molten lava cakes",
                    Description = "Description placeholder",
                    Price = 3.90m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Pastries"],
                    Name = "Cinnamon rolls",
                    Description = "Description placeholder",
                    Price = 2.15m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Cake"],
                    Name = "Cheesecake",
                    Description = "Description placeholder",
                    Price = 1.99m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Pastries"],
                    Name = "Baklava",
                    Description = "Description placeholder",
                    Price = 1.55m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Cake"],
                    Name = "Lemon cake",
                    Description = "Description placeholder",
                    Price = 2.75m,
                },
                new Product
                {
                    CategoryId = categoryDictionary["Pastries"],
                    Name = "Cannoli",
                    Description = "Description placeholder",
                    Price = 3
                },
                new Product
                {
                    CategoryId = categoryDictionary["Cake"],
                    Name = "Strawberry shortcake",
                    Description = "Description placeholder",
                    Price = 1.90m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Pastries"],
                    Name = "Apple cobbler",
                    Description = "Description placeholder",
                    Price = 2.20m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Carbonated drink"],
                    Name = "Coke",
                    Description = "Description placeholder",
                    Price = 1.50m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Carbonated drink"],
                    Name = "Coke light",
                    Description = "Description placeholder",
                    Price = 1.55m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Carbonated drink"],
                    Name = "Fanta",
                    Description = "Description placeholder",
                    Price = 1.55m,
                },
                new Product
                {
                    CategoryId = categoryDictionary["Beer"],
                    Name = "Bud Light",
                    Description = "Description placeholder",
                    Price = 2
                },
                new Product
                {
                    CategoryId = categoryDictionary["Beer"],
                    Name = "Coors Light",
                    Description = "Description placeholder",
                    Price = 1.90m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Beer"],
                    Name = "Corona Extra",
                    Description = "Description placeholder",
                    Price = 1.10m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Liquour"],
                    Name = "Whiskey",
                    Description = "Description placeholder",
                    Price = 3m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Liquour"],
                    Name = "Brandy",
                    Description = "Description placeholder",
                    Price = 3.10m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Liquour"],
                    Name = "Gin ",
                    Description = "Description placeholder",
                    Price = 1.90m,
                },
                new Product
                {
                    CategoryId = categoryDictionary["Liquour"],
                    Name = "Vodka",
                    Description = "Description placeholder",
                    Price = 2
                },
                new Product
                {
                    CategoryId = categoryDictionary["Liquour"],
                    Name = "Rum",
                    Description = "Description placeholder",
                    Price = 1.90m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Wine"],
                    Name = "Moscato",
                    Description = "white wine",
                    Price = 1.85m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Wine"],
                    Name = "Merlot",
                    Description = "Description placeholder",
                    Price = 1.85m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Juice"],
                    Name = "Apple Juice",
                    Description = "Description placeholder",
                    Price = 1.90m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Juice"],
                    Name = "Orange Juice",
                    Description = "Description placeholder",
                    Price = 2.50m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Juice"],
                    Name = "Peach Juice",
                    Description = "Description placeholder",
                    Price = 1.10m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Coffee"],
                    Name = "Expresso",
                    Description = "Description placeholder",
                    Price = 2.79m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Coffee"],
                    Name = "Decaf",
                    Description = "Description placeholder",
                    Price = 2.89m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Coffee"],
                    Name = "Arabica",
                    Description = "Description placeholder",
                    Price = 2.89m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Tea"],
                    Name = "Black Tea",
                    Description = "Description placeholder",
                    Price = 1.89m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Tea"],
                    Name = "Green Tea",
                    Description = "Description placeholder",
                    Price = 1.89m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Tea"],
                    Name = "White Tea",
                    Description = "Description placeholder",
                    Price = 1.89m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Water"],
                    Name = "Bottled Spring Water",
                    Description = "Description placeholder",
                    Price = 0.89m
                },
            };
    }
}
