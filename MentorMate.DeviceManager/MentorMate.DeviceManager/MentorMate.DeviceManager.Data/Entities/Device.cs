using System.ComponentModel.DataAnnotations;

namespace MentorMate.DeviceManager.Data.Entities
{
    public class Device
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Model { get; set; }
        [Required]
        [MaxLength(255)]
        public string Manufacturer { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        public DateTime? DateTaken { get; set; }

    }
}
