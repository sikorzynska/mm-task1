using MentorMate.Restaurant.Domain.Consts;
using System.ComponentModel.DataAnnotations;

namespace MentorMate.Restaurant.WebApp.Models.Users
{
    public class UserLoginFormModel
    {
        [Required(ErrorMessage = Messages.UserEmailRequired)]
        [MaxLength(255, ErrorMessage = Messages.UserEmailLength)]
        [EmailAddress(ErrorMessage = Messages.UserEmailInvalid)]
        public string Email { get; set; }
        [Required(ErrorMessage = Messages.UserPasswordRequired)]
        public string Password { get; set; }
    }
}
