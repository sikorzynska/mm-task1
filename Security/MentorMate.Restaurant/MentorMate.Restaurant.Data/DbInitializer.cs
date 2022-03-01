using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Data.Misc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MentorMate.Restaurant.Data
{
    public class DbInitializer
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public DbInitializer(RestaurantDbContext dbContext,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task InitializeAsync()
        {
            await ApplyMigrationsAsync();
            await SeedAsync();
        }

        private async Task ApplyMigrationsAsync()
        {
            var pendingMigrations = await _dbContext.Database.GetPendingMigrationsAsync();

            if (pendingMigrations.Any())
            {
                await _dbContext.Database.MigrateAsync();
            }
        }

        private async Task SeedAsync()
        {
            await SeedCategoriesAsync();
            await SeedProductsAsync();
            await SeedTablesAsync();
            await SeedRolesAsync();
            await SeedUsersAsync();
            await SeedOrdersAsync();
        }
        
        private async Task SeedRolesAsync()
        {
            if(await _dbContext.Roles.AnyAsync())
            {
                return;
            }

            var roles = new List<IdentityRole> 
            { 
                new IdentityRole
                {
                    Name = UserRoles.Admin
                },
                new IdentityRole
                {
                    Name = UserRoles.Waiter
                },
            };

            foreach (var role in roles)
            {
                await _roleManager.CreateAsync(role);
            }

            await _dbContext.SaveChangesAsync();
        }

        private async Task SeedUsersAsync()
        {
            if (await _dbContext.Users.AnyAsync())
            {
                return;
            }

            var adminUser = new User
            {
                FirstName = "Johnny",
                LastName = "Bravo",
                PictureURL = "https://i.pinimg.com/564x/1d/23/13/1d23132de642cbdc7898bfdf6da82ccd.jpg",
                Email = "admin@abv.bg",
                UserName = "admin123"
            };

            await _userManager.CreateAsync(adminUser, "Admin123!");
            await _userManager.AddToRoleAsync(adminUser, UserRoles.Admin);

            var waiterUser = new User
            {
                FirstName = "Jack",
                LastName = "Harlow",
                PictureURL = "https://i.musicaimg.com/letras/250x250/jack-harlow.jpg",
                Email = "waiter@abv.bg",
                UserName = "waiter123"
            };

            await _userManager.CreateAsync(waiterUser, "Waiter123!");
            await _userManager.AddToRoleAsync(waiterUser, UserRoles.Waiter);

            await _dbContext.SaveChangesAsync();
        }

        private async Task SeedCategoriesAsync()
        {
            if (await _dbContext.Categories.AnyAsync())
            {
                return;
            }

            var categories = FoodCategories.GetCategories();

            await _dbContext.Categories.AddRangeAsync(categories);
        }

        private async Task SeedProductsAsync()
        {
            if (await _dbContext.Products.AnyAsync())
            {
                return;
            }

            var products = FoodMenu.GetProducts();

            await _dbContext.Products.AddRangeAsync(products);
        }

        private async Task SeedTablesAsync()
        {
            if (await _dbContext.Tables.AnyAsync())
            {
                return;
            }

            var tables = new List<Table>();

            var rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                tables.Add(new Table
                {
                    Capacity = rnd.Next(2, 13)
                });
            }

            await _dbContext.Tables.AddRangeAsync(tables);

            await _dbContext.SaveChangesAsync();
        }

        private async Task SeedOrdersAsync()
        {
            if(await _dbContext.Orders.AnyAsync())
            {
                return;
            }

            var rnd = new Random();

            var orders = new List<Order>();

            for (int i = 0; i < 20; i++)
            {
                var tableId = rnd.Next(1, 11);

                var waiterId = _userManager.GetUsersInRoleAsync(UserRoles.Waiter).Result.FirstOrDefault().Id;

                var order = new Order
                {
                    TableId = tableId,
                    WaiterId = waiterId,
                };

                orders.Add(order);
            }

            await _dbContext.Orders.AddRangeAsync(orders);

            await _dbContext.SaveChangesAsync();

            var dbOrders = await _dbContext.Orders.ToListAsync();

            foreach (var order in dbOrders)
            {
                var count = rnd.Next(1, 6);

                for (int j = 0; j < count; j++)
                {
                    var product = await _dbContext.Products.OrderBy(x => new Guid().ToString()).FirstOrDefaultAsync();

                    var productCount = rnd.Next(1, 4);

                    var op = new OrderProduct
                    {
                        OrderId = order.Id,
                        ProductId = product.Id,
                        ProductCount = productCount,
                    };

                    await _dbContext.OrderProducts.AddAsync(op);
                }
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
