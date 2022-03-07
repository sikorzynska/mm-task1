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
                    CategoryId = categoryDictionary["Main Menu"],
                    Name = "Roasted chicken",
                    Description = "Description placeholder",
                    Price = 9.99m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Main Menu"],
                    Name = "Chicken pot pie.",
                    Description = "Description placeholder",
                    Price = 6.65m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Appetizer"],
                    Name = "Mashed potatoes",
                    Description = "Description placeholder",
                    Price = 4.20m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Main Menu"],
                    Name = "Fried chicken",
                    Description = "Description placeholder",
                    Price = 5.99m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Main Menu"],
                    Name = "Beef burger",
                    Description = "Description placeholder",
                    Price = 5
                },
                new Product
                {
                    CategoryId = categoryDictionary["Main Menu"],
                    Description = "Description placeholder",
                    Name = "Chicken burger",
                    Price = 5
                },
                new Product
                {
                    CategoryId = categoryDictionary["Main Menu"],
                    Name = "Pork burger",
                    Description = "Description placeholder",
                    Price = 5
                },
                new Product
                {
                    CategoryId = categoryDictionary["Main Menu"],
                    Description = "Description placeholder",
                    Name = "Veggie burger",
                    Price = 4.10m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Main Menu"],
                    Name = "Pepperoni pizza",
                    Description = "Description placeholder",
                    Price = 5.35m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Main Menu"],
                    Name = "Vegeterian pizza",
                    Description = "Description placeholder",
                    Price = 4.35m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Main Menu"],
                    Name = "Chicken soup",
                    Description = "Description placeholder",
                    Price = 3.10m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Main Menu"],
                    Name = "Meatloaf",
                    Description = "Description placeholder",
                    Price = 8.85m,
                },
                new Product
                {
                    CategoryId = categoryDictionary["Main Menu"],
                    Name = "Lasagna",
                    Description = "Description placeholder",
                    Price = 7.85m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Main Menu"],
                    Name = "Spaghetti with meatballs",
                    Description = "Description placeholder",
                    Price = 4.10m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Appetizer"],
                    Name = "Mozzarella sticks",
                    Description = "Description placeholder",
                    Price = 2.35m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Appetizer"],
                    Name = "Cheddar biscuits",
                    Description = "Description placeholder",
                    Price = 2.35m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Appetizer"],
                    Name = "Pigs in a blanket",
                    Description = "Description placeholder",
                    Price = 3.90m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Appetizer"],
                    Name = "Spinach cheese dip with chips",
                    Description = "Description placeholder",
                    Price = 6.05m,
                },
                new Product
                {
                    CategoryId = categoryDictionary["Appetizer"],
                    Name = "Onion rings",
                    Description = "Description placeholder",
                    Price = 2.85m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Appetizer"],
                    Name = "French fries",
                    Description = "Description placeholder",
                    Price = 2.90m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Appetizer"],
                    Name = "Breadsticks",
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
                    CategoryId = categoryDictionary["Non-alcoholic"],
                    Name = "Coke",
                    Description = "Description placeholder",
                    Price = 1.50m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Non-alcoholic"],
                    Name = "Coke light",
                    Description = "Description placeholder",
                    Price = 1.55m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Non-alcoholic"],
                    Name = "Fanta",
                    Description = "Description placeholder",
                    Price = 1.55m,
                },
                new Product
                {
                    CategoryId = categoryDictionary["Beer"],
                    Name = "Beer",
                    Description = "Description placeholder",
                    Price = 2
                },
                new Product
                {
                    CategoryId = categoryDictionary["Beer"],
                    Name = "Cider",
                    Description = "Description placeholder",
                    Price = 1.90m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Water"],
                    Name = "Bottled water",
                    Description = "Description placeholder",
                    Price = 1.10m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Base liquor"],
                    Name = "Whiskey",
                    Description = "Description placeholder",
                    Price = 3m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Base liquor"],
                    Name = "Brandy",
                    Description = "Description placeholder",
                    Price = 3.10m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Base liquor"],
                    Name = "Gin ",
                    Description = "Description placeholder",
                    Price = 1.90m,
                },
                new Product
                {
                    CategoryId = categoryDictionary["Base liquor"],
                    Name = "Vodka",
                    Description = "Description placeholder",
                    Price = 2
                },
                new Product
                {
                    CategoryId = categoryDictionary["Base liquor"],
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
                    CategoryId = categoryDictionary["Breakfast"],
                    Name = "Cereal",
                    Description = "Description placeholder",
                    Price = 1.90m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Breakfast"],
                    Name = "Egg omelette",
                    Description = "Description placeholder",
                    Price = 2.50m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Pastries"],
                    Name = "Croissant",
                    Description = "Description placeholder",
                    Price = 1.10m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Pastries"],
                    Name = "Waffles",
                    Description = "Description placeholder",
                    Price = 2.79m
                },
                new Product
                {
                    CategoryId = categoryDictionary["Pastries"],
                    Name = "Pancakes",
                    Description = "Description placeholder",
                    Price = 2.89m
                },
            };
    }
}
