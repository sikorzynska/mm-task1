using MentorMate.Restaurant.Domain.Consts;
using System.ComponentModel.DataAnnotations;

namespace MentorMate.Restaurant.Domain.Models.Users
{
    public class CreateUserModel
    {
        [Required(ErrorMessage = Messages.UserNameRequired)]
        [MaxLength(100, ErrorMessage = Messages.UserNameLength)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = Messages.UserNameRequired)]
        [MaxLength(100, ErrorMessage = Messages.UserNameLength)]
        public string LastName { get; set; }

        [Required(ErrorMessage = Messages.UserUsernameRequired)]
        [MaxLength(100, ErrorMessage = Messages.UserUsernameLength)]
        public string Username { get; set; }

        [Required(ErrorMessage = Messages.UserEmailRequired)]
        [MaxLength(255, ErrorMessage = Messages.UserEmailLength)]
        [EmailAddress(ErrorMessage = Messages.UserEmailInvalid)]
        public string Email { get; set; }

        [RegularExpression(RegEx.ImageUrl, ErrorMessage = Messages.UserImageUrlInvalid)]
        public string? PictureURL { get; set; }

        [Required(ErrorMessage = Messages.UserRoleRequired)]
        public string Role { get; set; }

        [Required(ErrorMessage = Messages.UserPasswordRequired)]
        [MinLength(8, ErrorMessage = Messages.UserPasswordLength),
            MaxLength(100, ErrorMessage = Messages.UserPasswordLength)]
        public string Password { get; set; }
    }
}
