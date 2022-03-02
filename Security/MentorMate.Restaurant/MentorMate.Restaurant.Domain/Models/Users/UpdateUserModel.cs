using MentorMate.Restaurant.Domain.Consts;
using System.ComponentModel.DataAnnotations;

namespace MentorMate.Restaurant.Domain.Models.Users
{
    public class UpdateUserModel
    {
        [Required]
        public string? Id { get; set; }

        [MaxLength(100, ErrorMessage = Messages.UserNameLength)]
        public string? FirstName { get; set; }

        [MaxLength(100, ErrorMessage = Messages.UserNameLength)]
        public string? LastName { get; set; }

        [RegularExpression(RegEx.ImageUrl, ErrorMessage = Messages.UserImageUrlInvalid)]
        public string? PictureURL { get; set; }

        [MaxLength(100, ErrorMessage = Messages.UserNameLength)]
        public string? Username { get; set; }

        [MaxLength(255, ErrorMessage = Messages.UserEmailLength)]
        [EmailAddress(ErrorMessage = Messages.UserEmailInvalid)]
        public string? Email { get; set; }

        public string? Role { get; set; }

        [MinLength(8, ErrorMessage = Messages.UserPasswordLength),
            MaxLength(100, ErrorMessage = Messages.UserPasswordLength)]
        public string? Password { get; set; }
    }
}
