using MentorMate.Restaurant.Domain.Consts;
using System.ComponentModel.DataAnnotations;

namespace MentorMate.Restaurant.Domain.Models.Users
{
    public class UserModel
    {
        [Required(ErrorMessage = Errors.NameRequired)]
        [MaxLength(100, ErrorMessage = Errors.NameRequired)]
        public string Name { get; set; }

        [Required(ErrorMessage = Errors.EmailRequired)]
        [MaxLength(255, ErrorMessage = Errors.EmailRequired)]
        [EmailAddress(ErrorMessage = Errors.InvalidEmail)]
        public string Email { get; set; }

        [Required(ErrorMessage = Errors.RoleRequired)]
        public string Role { get; set; }

        [Required(ErrorMessage = Errors.PasswordRequired)]
        [MinLength(8, ErrorMessage = Errors.PasswordRequired)]
        public string Password { get; set; }
    }
}
