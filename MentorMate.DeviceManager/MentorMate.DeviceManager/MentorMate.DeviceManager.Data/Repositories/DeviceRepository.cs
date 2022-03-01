using MentorMate.DeviceManager.Data.Entities;
using MentorMate.DeviceManager.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MentorMate.DeviceManager.Data.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly DeviceManagerDbContext _dbContext;

        public DeviceRepository(DeviceManagerDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        //Get all
        public async Task<IEnumerable<Device>> GetAllAsync() =>
            await _dbContext.Devices.ToListAsync();

        //Get by id
        public async Task<Device> GetByIdAsync(string id) =>
            await _dbContext.Devices.FirstOrDefaultAsync(d => d.Id == id);

        //Get by name
        public async Task<Device> GetByNameAsync(string name) =>
            await _dbContext.Devices.FirstOrDefaultAsync(d => d.Name == name);

        //Create
        public async Task CreateAsync(Device device)
        {
            await _dbContext.Devices.AddAsync(device);

            await _dbContext.SaveChangesAsync();
        }

        //Update
        public async Task UpdateAsync(Device device)
        {
            _dbContext.Devices.Update(device);

            await _dbContext.SaveChangesAsync();
        }

        //Delete
        public async Task DeleteAsync(Device device)
        {
            _dbContext.Devices.Remove(device);

            await _dbContext.SaveChangesAsync();
        }
    }
}
