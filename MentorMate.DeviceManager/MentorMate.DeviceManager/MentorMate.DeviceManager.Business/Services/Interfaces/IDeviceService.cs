using MentorMate.DeviceManager.Domain.Models.Devices;
using MentorMate.DeviceManager.Domain.Models.Sorting;

namespace MentorMate.DeviceManager.Business.Services.Interfaces
{
    public interface IDeviceService
    {
        Task<IEnumerable<GeneralDeviceModel>> GetAllAsync(SortingModel model);
        Task<GeneralDeviceModel> GetByIdAsync(string id);
        Task<GeneralDeviceResponse> CreateAsync(CreateDeviceModel model);
        Task<GeneralDeviceResponse> DeleteAsync(string id);
        Task<GeneralDeviceResponse> UpdateAsync(string id, UpdateDeviceModel model);
    }
}
