using MentorMate.Restaurant.Domain.Consts;
using System.ComponentModel.DataAnnotations;

namespace MentorMate.Restaurant.Domain.Models.Users
{
    public class CreateUserModel
    {
        [Required(ErrorMessage = Messages.NameRequiredMessage)]
        [MaxLength(100, ErrorMessage = Messages.NameLengthMessage)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = Messages.NameRequiredMessage)]
        [MaxLength(100, ErrorMessage = Messages.NameLengthMessage)]
        public string LastName { get; set; }

        [Required(ErrorMessage = Messages.UsernameRequiredMessage)]
        [MaxLength(100, ErrorMessage = Messages.UsernameLengthMessage)]
        public string Username { get; set; }

        [Required(ErrorMessage = Messages.EmailRequiredMessage)]
        [MaxLength(255, ErrorMessage = Messages.EmailLengthMessage)]
        [EmailAddress(ErrorMessage = Messages.InvalidEmailMessage)]
        public string Email { get; set; }

        [RegularExpression(RegEx.ImageUrl, ErrorMessage = Messages.ImageUrlInvalid)]
        public string? PictureURL { get; set; }

        [Required(ErrorMessage = Messages.RoleRequiredMessage)]
        public string Role { get; set; }

        [Required(ErrorMessage = Messages.PasswordRequiredMessage)]
        [MinLength(8, ErrorMessage = Messages.PasswordLengthMessage),
            MaxLength(100, ErrorMessage = Messages.PasswordLengthMessage)]
        public string Password { get; set; }
    }
}
