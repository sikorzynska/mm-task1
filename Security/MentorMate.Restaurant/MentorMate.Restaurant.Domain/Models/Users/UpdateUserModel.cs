using MentorMate.Restaurant.Domain.Consts;
using System.ComponentModel.DataAnnotations;

namespace MentorMate.Restaurant.Domain.Models.Users
{
    public class UpdateUserModel
    {
        [Required]
        public string? Id { get; set; }

        [MaxLength(100, ErrorMessage = Messages.NameLengthMessage)]
        public string? Username { get; set; }

        [MaxLength(255, ErrorMessage = Messages.EmailLengthMessage)]
        [EmailAddress(ErrorMessage = Messages.InvalidEmailMessage)]
        public string? Email { get; set; }

        public string? Role { get; set; }

        [MinLength(8, ErrorMessage = Messages.PasswordLengthMessage),
            MaxLength(100, ErrorMessage = Messages.PasswordLengthMessage)]
        public string? Password { get; set; }
    }
}
