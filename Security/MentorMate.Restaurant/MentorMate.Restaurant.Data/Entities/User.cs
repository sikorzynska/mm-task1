using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MentorMate.Restaurant.Data.Entities
{
    public class User : IdentityUser
    {
        [MaxLength(100)]
        public string? FirstName { get; set; }
        [MaxLength(100)]
        public string? LastName { get; set; }
        public string? PictureURL { get; set; }
    }
}
