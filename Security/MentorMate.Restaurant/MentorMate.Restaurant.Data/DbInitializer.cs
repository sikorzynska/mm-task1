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
                UserName = "admin123",
            };

            await _userManager.CreateAsync(adminUser, "Admin123!");
            await _userManager.AddToRoleAsync(adminUser, UserRoles.Admin);

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

            for (int i = 0; i < 10; i++)
            {
                tables.Add(new Table());
            }

            await _dbContext.Tables.AddRangeAsync(tables);

            await _dbContext.SaveChangesAsync();
        }
    }
}
