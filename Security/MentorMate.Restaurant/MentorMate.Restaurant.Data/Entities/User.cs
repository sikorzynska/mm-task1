using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MentorMate.Restaurant.Data.Entities
{
    public class User : IdentityUser
    {
        [Required]
        public string? Name { get; set; }
        public ICollection<Table>? Tables { get; set; } = new List<Table>();
    }
}
