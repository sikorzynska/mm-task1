using MentorMate.Restaurant.Data.Entities;

namespace MentorMate.Restaurant.Data.Misc
{
    public static class FoodMenu
    {
        public static ICollection<Product> GetProducts() =>
            new List<Product>
            {
                new Product
                {
                    CategoryId = 3,
                    Name = "Roasted chicken",
                    Price = 9.99m
                },
                new Product
                {
                    CategoryId = 3,
                    Name = "Chicken pot pie.",
                    Price = 6.65m
                },
                new Product
                {
                    CategoryId = 1,
                    Name = "Mashed potatoes",
                    Price = 4.20m
                },
                new Product
                {
                    CategoryId = 3,
                    Name = "Fried chicken",
                    Price = 5.99m
                },
                new Product
                {
                    CategoryId = 3,
                    Name = "Beef burger",
                    Price = 5
                },
                new Product
                {
                    CategoryId = 3,
                    Name = "Chicken burger",
                    Price = 5
                },
                new Product
                {
                    CategoryId = 3,
                    Name = "Pork burger",
                    Price = 5
                },
                new Product
                {
                    CategoryId = 3,
                    Name = "Veggie burger",
                    Price = 4.10m
                },
                new Product
                {
                    CategoryId = 3,
                    Name = "Pepperoni pizza",
                    Price = 5.35m
                },
                new Product
                {
                    CategoryId = 3,
                    Name = "Vegeterian pizza",
                    Price = 4.35m
                },
                new Product
                {
                    CategoryId = 3,
                    Name = "Chicken soup",
                    Price = 3.10m
                },
                new Product
                {
                    CategoryId = 3,
                    Name = "Meatloaf",
                    Price = 8.85m,
                },
                new Product
                {
                    CategoryId = 3,
                    Name = "Lasagna",
                    Price = 7.85m
                },
                new Product
                {
                    CategoryId = 3,
                    Name = "Spaghetti with meatballs",
                    Price = 4.10m
                },
                new Product
                {
                    CategoryId = 1,
                    Name = "Mozzarella sticks",
                    Price = 2.35m
                },
                new Product
                {
                    CategoryId = 1,
                    Name = "Cheddar biscuits",
                    Price = 2.35m
                },
                new Product
                {
                    CategoryId = 1,
                    Name = "Pigs in a blanket",
                    Price = 3.90m
                },
                new Product
                {
                    CategoryId = 1,
                    Name = "Spinach cheese dip with chips",
                    Price = 6.05m,
                },
                new Product
                {
                    CategoryId = 1,
                    Name = "Onion rings",
                    Price = 2.85m
                },
                new Product
                {
                    CategoryId = 1,
                    Name = "French fries",
                    Price = 2.90m
                },
                new Product
                {
                    CategoryId = 1,
                    Name = "Breadsticks",
                    Price = 2.15m
                },
                new Product
                {
                    CategoryId = 4,
                    Name = "Apple pie",
                    Price = 1.35m
                },
                new Product
                {
                    CategoryId = 4,
                    Name = "Pumpkin pie",
                    Price = 1.60m
                },
                new Product
                {
                    CategoryId = 4,
                    Name = "Giant chocolate chip cookies",
                    Price = 2.05m,
                },
                new Product
                {
                    CategoryId = 4,
                    Name = "Banana split",
                    Price = 3.85m
                },
                new Product
                {
                    CategoryId = 4,
                    Name = "Molten lava cakes",
                    Price = 3.90m
                },
                new Product
                {
                    CategoryId = 4,
                    Name = "Cinnamon rolls",
                    Price = 2.15m
                },
                new Product
                {
                    CategoryId = 4,
                    Name = "Cheesecake",
                    Price = 1.99m
                },
                new Product
                {
                    CategoryId = 4,
                    Name = "Baklava",
                    Price = 1.55m
                },
                new Product
                {
                    CategoryId = 4,
                    Name = "Lemon cake",
                    Price = 2.75m,
                },
                new Product
                {
                    CategoryId = 4,
                    Name = "Cannoli",
                    Price = 3
                },
                new Product
                {
                    CategoryId = 4,
                    Name = "Strawberry shortcake",
                    Price = 1.90m
                },
                new Product
                {
                    CategoryId = 4,
                    Name = "Apple cobbler",
                    Price = 2.20m
                },
                new Product
                {
                    CategoryId = 5,
                    Name = "Coke",
                    Price = 1.50m
                },
                new Product
                {
                    CategoryId = 5,
                    Name = "Coke light",
                    Price = 1.55m
                },
                new Product
                {
                    CategoryId = 5,
                    Name = "Fanta",
                    Price = 1.55m,
                },
                new Product
                {
                    CategoryId = 5,
                    Name = "Beer",
                    Price = 2
                },
                new Product
                {
                    CategoryId = 5,
                    Name = "Cider",
                    Price = 1.90m
                },
                new Product
                {
                    CategoryId = 5,
                    Name = "Bottled water",
                    Price = 1.10m
                },
                new Product
                {
                    CategoryId = 5,
                    Name = "Whiskey",
                    Price = 3m
                },
                new Product
                {
                    CategoryId = 5,
                    Name = "Brandy",
                    Price = 3.10m
                },
                new Product
                {
                    CategoryId = 5,
                    Name = "Gin ",
                    Price = 1.90m,
                },
                new Product
                {
                    CategoryId = 5,
                    Name = "Vodka",
                    Price = 2
                },
                new Product
                {
                    CategoryId = 5,
                    Name = "Rum",
                    Price = 1.90m
                },
                new Product
                {
                    CategoryId = 5,
                    Name = "White wine",
                    Price = 1.85m
                },
                new Product
                {
                    CategoryId = 5,
                    Name = "Red wine",
                    Price = 1.85m
                },
                new Product
                {
                    CategoryId = 2,
                    Name = "Cereal",
                    Price = 1.90m
                },
                new Product
                {
                    CategoryId = 2,
                    Name = "Egg omelette",
                    Price = 2.50m
                },
                new Product
                {
                    CategoryId = 2,
                    Name = "Croissant",
                    Price = 1.10m
                },
                new Product
                {
                    CategoryId = 2,
                    Name = "Waffles",
                    Price = 2.79m
                },
                new Product
                {
                    CategoryId = 2,
                    Name = "Pancakes",
                    Price = 2.89m
                },
            };
    }
}
