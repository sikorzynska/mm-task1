using System.ComponentModel.DataAnnotations;

namespace MentorMate.Restaurant.Domain.Models.Auth
{
    public class AuthorizeRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
