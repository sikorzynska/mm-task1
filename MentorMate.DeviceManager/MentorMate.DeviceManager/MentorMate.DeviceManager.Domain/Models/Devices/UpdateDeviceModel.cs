using MentorMate.DeviceManager.Domain.Constants;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MentorMate.DeviceManager.Domain.Models.Devices
{
    public class UpdateDeviceModel
    {
        [MaxLength(255, ErrorMessage = Messages.DeviceNameLength)]
        public string? Name { get; set; }

        [MaxLength(255, ErrorMessage = Messages.DeviceModelLength)]
        public string? Model { get; set; }

        [MaxLength(255, ErrorMessage = Messages.DeviceManufacturerLength)]
        public string? Manufacturer { get; set; }

        [JsonPropertyName("release_data")]
        public DateTime? ReleaseDate { get; set; }

        [JsonPropertyName("taken_date")]
        public DateTime? DateTaken { get; set; }
    }
}
