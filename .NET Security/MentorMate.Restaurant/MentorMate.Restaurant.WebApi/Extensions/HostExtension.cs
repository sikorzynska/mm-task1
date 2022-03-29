using MentorMate.Restaurant.Data;

namespace MentorMate.Restaurant.WebApi.Extensions
{
    public static class HostExtension
    {
        public static async Task InitializeDbContext(this IHost host)
        {
            using(var scope = host.Services.CreateScope())
            {
                var databaseInitializer = scope.ServiceProvider.GetRequiredService<DbInitializer>();

                await databaseInitializer.InitializeAsync();
            }
        }
    }
}
