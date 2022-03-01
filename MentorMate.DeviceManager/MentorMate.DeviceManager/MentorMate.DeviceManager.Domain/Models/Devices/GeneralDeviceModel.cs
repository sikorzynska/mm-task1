using System.Text.Json.Serialization;

namespace MentorMate.DeviceManager.Domain.Models.Devices
{
    public class GeneralDeviceModel
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Model { get; set; }
        public string? Manufacturer { get; set; }
        [JsonPropertyName("release_date")]
        public string? ReleaseDate { get; set; }
        [JsonPropertyName("taken_date")]
        public string? DateTaken { get; set; }
    }
}
