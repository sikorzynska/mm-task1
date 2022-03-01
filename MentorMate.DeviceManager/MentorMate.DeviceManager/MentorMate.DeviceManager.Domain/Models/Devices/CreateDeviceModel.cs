using MentorMate.DeviceManager.Domain.Constants;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MentorMate.DeviceManager.Domain.Models.Devices
{
    public class CreateDeviceModel
    {
        [Required(ErrorMessage = Messages.DeviceNameRequired)]
        [MaxLength(255, ErrorMessage = Messages.DeviceNameLength)]
        public string? Name { get; set; }

        [Required(ErrorMessage = Messages.DeviceModelRequired)]
        [MaxLength(255, ErrorMessage = Messages.DeviceModelLength)]
        public string? Model { get; set; }

        [Required(ErrorMessage = Messages.DeviceManufacturerRequired)]
        [MaxLength(255, ErrorMessage = Messages.DeviceManufacturerLength)]
        public string? Manufacturer { get; set; }

        [JsonPropertyName("release_date")]
        [Required(ErrorMessage = Messages.DeviceReleaseDateRequired)]
        public DateTime ReleaseDate { get; set; }

        [JsonPropertyName("taken_date")]
        public DateTime? DateTaken { get; set; }
    }
}
