using MentorMate.DeviceManager.Business.Services.Interfaces;
using MentorMate.DeviceManager.Data.Entities;
using MentorMate.DeviceManager.Data.Repositories.Interfaces;
using MentorMate.DeviceManager.Domain.Constants;
using MentorMate.DeviceManager.Domain.Models.Devices;
using MentorMate.DeviceManager.Domain.Models.Sorting;

namespace MentorMate.DeviceManager.Business.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeviceService(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository ?? throw new ArgumentNullException(nameof(deviceRepository));
        }

        public async Task<IEnumerable<GeneralDeviceModel>> GetAllAsync(SortingModel model)
        {
            var devices = await _deviceRepository.GetAllAsync();

            if(model.TakenSince != null)
            {
                devices = devices.Where(d => d.DateTaken != null && d.DateTaken >= model.TakenSince);
            }

            if(model.Manufacturer != null)
            {
                devices = devices.Where(d => d.Manufacturer == model.Manufacturer);
            }

            if(model.ReleaseDateFrom != null)
            {
                devices = devices.Where(d => d.ReleaseDate >= model.ReleaseDateFrom);
            }

            if(model.ReleaseDateTo != null)
            {
                devices = devices.Where(d => d.ReleaseDate <= model.ReleaseDateTo);
            }

            if(model.IsTaken != null)
            {
                if(model.IsTaken.Value)
                {
                    devices = devices.Where(d => d.DateTaken != null);
                }
                else
                {
                    devices = devices.Where(d => d.DateTaken == null);
                }
            }

            var result = devices.OrderByDescending(x => x.ReleaseDate)
                .Select(d => new GeneralDeviceModel
            {
                Id = d.Id,
                Name = d.Name,
                Model = d.Model,
                Manufacturer = d.Manufacturer,
                ReleaseDate = d.ReleaseDate.ToString("dddd, dd MMMM yyyy"),
                DateTaken = d.DateTaken != null 
                ? d.DateTaken.Value.ToString("dddd, dd MMMM yyyy") 
                : "N/A"
            });

            return result;
        }

        public async Task<GeneralDeviceModel> GetByIdAsync(string id)
        {
            var device = await _deviceRepository.GetByIdAsync(id);

            if(device == null)
            {
                return null;
            }

            var result = new GeneralDeviceModel
            {
                Id = device.Id,
                Name = device.Name,
                Model = device.Model,
                Manufacturer = device.Manufacturer,
                ReleaseDate = device.ReleaseDate.ToString("dddd, dd MMMM yyyy"),
                DateTaken = device.DateTaken != null
                ? device.DateTaken.Value.ToString("dddd, dd MMMM yyyy")
                : "N/A"
            };

            return result;
        }

        public async Task<GeneralDeviceResponse> CreateAsync(CreateDeviceModel model)
        {
            var result = new GeneralDeviceResponse();

            if(await NameTaken(model.Name))
            {
                result = new GeneralDeviceResponse(false, Messages.DeviceNameTaken);

                return result;
            }

            var device = new Device
            {
                Name = model.Name,
                Model = model.Model,
                Manufacturer = model.Manufacturer,
                ReleaseDate = model.ReleaseDate,
                DateTaken = model.DateTaken ?? null
            };

            await _deviceRepository.CreateAsync(device);

            result = new GeneralDeviceResponse(true, Messages.DeviceCreated, new GeneralDeviceModel
            {
                Id = device.Id,
                Name = device.Name,
                Model = device.Model,
                Manufacturer = device.Manufacturer,
                ReleaseDate = device.ReleaseDate.ToString("dddd, dd MMMM yyyy"),
                DateTaken = device.DateTaken != null
                ? device.DateTaken.Value.ToString("dddd, dd MMMM yyyy")
                : "N/A"
            });

            return result;
        }

        public async Task<GeneralDeviceResponse> UpdateAsync(string id, UpdateDeviceModel model)
        {
            var result = new GeneralDeviceResponse();

            if(id == null)
            {
                result = new GeneralDeviceResponse(false, string.Format(Messages.DeviceIdRequired, id));

                return result;
            }

            var device = await _deviceRepository.GetByIdAsync(id);

            if (device == null)
            {
                result = new GeneralDeviceResponse(false, string.Format(Messages.DeviceNotFound, id));

                return result;
            }

            if (device.Name != model.Name && await NameTaken(model.Name))
            {
                result = new GeneralDeviceResponse(false, Messages.DeviceNameTaken);

                return result;
            }

            device.Name = model.Name ?? device.Name;
            device.Model = model.Model ?? device.Model;
            device.Manufacturer = model.Manufacturer ?? device.Manufacturer;
            device.ReleaseDate = model.ReleaseDate ?? device.ReleaseDate;
            device.DateTaken = model.DateTaken ?? device.DateTaken;

            await _deviceRepository.UpdateAsync(device);

            result = new GeneralDeviceResponse(true, Messages.DeviceUpdated, new GeneralDeviceModel
            {
                Id = device.Id,
                Name = device.Name,
                Model = device.Model,
                Manufacturer = device.Manufacturer,
                ReleaseDate = device.ReleaseDate.ToString("dddd, dd MMMM yyyy"),
                DateTaken = device.DateTaken != null
                ? device.DateTaken.Value.ToString("dddd, dd MMMM yyyy")
                : "N/A"
            });

            return result;
        }

        public async Task<GeneralDeviceResponse> DeleteAsync(string id)
        {
            var result = new GeneralDeviceResponse();

            var device = await _deviceRepository.GetByIdAsync(id);

            if(device == null)
            {
                result = new GeneralDeviceResponse(false, string.Format(Messages.DeviceNotFound, id));

                return result;
            }

            result = new GeneralDeviceResponse(true, Messages.DeviceDeleted, new GeneralDeviceModel
            {
                Id = device.Id,
                Name = device.Name,
                Model = device.Model,
                Manufacturer = device.Manufacturer,
                ReleaseDate = device.ReleaseDate.ToString("dddd, dd MMMM yyyy"),
                DateTaken = device.DateTaken != null
                ? device.DateTaken.Value.ToString("dddd, dd MMMM yyyy")
                : "N/A"
            });

            return result;
        }

        private async Task<bool> NameTaken(string name)
        {
            var device = await _deviceRepository.GetByNameAsync(name);

            if(device == null)
            {
                return false;
            }

            return true;
        }
    }
}
