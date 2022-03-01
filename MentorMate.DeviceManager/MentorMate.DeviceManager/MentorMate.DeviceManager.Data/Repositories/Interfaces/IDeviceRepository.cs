using MentorMate.DeviceManager.Data.Entities;

namespace MentorMate.DeviceManager.Data.Repositories.Interfaces
{
    public interface IDeviceRepository
    {
        Task<IEnumerable<Device>> GetAllAsync();
        Task<Device> GetByIdAsync(string id);
        Task<Device> GetByNameAsync(string name);
        Task CreateAsync(Device device);
        Task DeleteAsync(Device device);
        Task UpdateAsync(Device device);
    }
}
