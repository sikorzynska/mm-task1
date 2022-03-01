using MentorMate.DeviceManager.Data;

namespace MentorMate.DeviceManager.WebApi.Extensions
{
    public static class HostExtensions
    {
        public static async Task InitializeDbContext(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var databaseInitializer = scope.ServiceProvider.GetRequiredService<DbInitializer>();

                await databaseInitializer.InitializeAsync();
            }
        }
    }
}
