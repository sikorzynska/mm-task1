using MentorMate.DeviceManager.Business.Services.Interfaces;
using MentorMate.DeviceManager.Domain.Models.Devices;
using MentorMate.DeviceManager.Domain.Models.Sorting;
using Microsoft.AspNetCore.Mvc;

namespace MentorMate.DeviceManager.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DevicesController : Controller
    {
        private readonly IDeviceService _deviceService;

        public DevicesController(IDeviceService deviceService)
        {
            _deviceService = deviceService ?? throw new ArgumentNullException(nameof(deviceService));
        }

        [HttpGet]
        public async Task<IActionResult> GetDevices([FromQuery] SortingModel model)
        {
            var devices = await _deviceService.GetAllAsync(model);

            if (!devices.Any())
            {
                return NotFound();
            }

            return Ok(devices);
        }

        [HttpGet("{deviceId}")]
        public async Task<IActionResult> GetDevice([FromRoute] string deviceId)
        {
            var device = await _deviceService.GetByIdAsync(deviceId);

            if(device == null)
            {
                return NotFound();
            }

            return Ok(device);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDevice([FromBody] CreateDeviceModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _deviceService.CreateAsync(model);

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("{deviceId}")]
        public async Task<IActionResult> UpdateDevice([FromRoute] string deviceId, [FromQuery] UpdateDeviceModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _deviceService.UpdateAsync(deviceId, model);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("{deviceId}")]
        public async Task<IActionResult> DeleteDevice([FromRoute] string deviceId)
        {
            var response = await _deviceService.DeleteAsync(deviceId);

            if(!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
