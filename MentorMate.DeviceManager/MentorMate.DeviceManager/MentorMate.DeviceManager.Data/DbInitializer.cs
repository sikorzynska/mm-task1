using MentorMate.DeviceManager.Data.Misc;
using Microsoft.EntityFrameworkCore;

namespace MentorMate.DeviceManager.Data
{
    public class DbInitializer
    {
        private readonly DeviceManagerDbContext _dbContext;

        public DbInitializer(DeviceManagerDbContext dbContext)
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
            await SeedDevicesAsync();
        }

        private async Task SeedDevicesAsync()
        {
            if(await _dbContext.Devices.AnyAsync())
            {
                return;
            }

            var devices = Devices.All;

            await _dbContext.AddRangeAsync(devices);

            await _dbContext.SaveChangesAsync();
        }
    }
}
