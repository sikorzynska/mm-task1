using System.Text.Json.Serialization;

namespace MentorMate.DeviceManager.Domain.Models.Sorting
{
    public class SortingModel
    {
        [JsonPropertyName("taken_since")]
        public DateTime? TakenSince { get; set; }
        public string? Manufacturer { get; set; }
        [JsonPropertyName("released_since")]
        public DateTime? ReleaseDateFrom { get; set; }
        [JsonPropertyName("release_to")]
        public DateTime? ReleaseDateTo { get; set; }
        [JsonPropertyName("taken")]
        public bool? IsTaken { get; set; }
    }
}
