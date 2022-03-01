using MentorMate.DeviceManager.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MentorMate.DeviceManager.Data
{
    public class DeviceManagerDbContext : DbContext
    {
        public DeviceManagerDbContext()
            : base()
        {
        }

        public DeviceManagerDbContext(DbContextOptions<DeviceManagerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Device> Devices { get; set; }
    }
}