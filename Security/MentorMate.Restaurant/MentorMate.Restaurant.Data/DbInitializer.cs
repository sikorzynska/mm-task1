using Microsoft.EntityFrameworkCore;

namespace MentorMate.Restaurant.Data
{
    public class DbInitializer
    {
        private readonly RestaurantDbContext _dbContext;

        public DbInitializer(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
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
            //await SeedUsersAsync();
            //await SeedProductsAsync();
            //await SeedTablesAsync();
        }

        private async Task SeedUsersAsync()
        {
            if (await _dbContext.Users.AnyAsync())
            {
                return;
            }

            //todo: implement logic
        }

        private async Task SeedProductsAsync()
        {
            if (await _dbContext.Products.AnyAsync())
            {
                return;
            }

            //todo: implement logic
        }

        private async Task SeedTablesAsync()
        {
            if (await _dbContext.Tables.AnyAsync())
            {
                return;
            }

            //todo: implement logic
        }
    }
}
