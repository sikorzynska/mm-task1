namespace MentorMate.Restaurant.Domain.Consts
{
    public static class Errors
    {
        public const string LoginError = "Invalid email or password";
        public const string NameRequired = "Name is required and must not exceed 100 characters";
        public const string EmailRequired = "Email is required and must not exceed 255 characters";
        public const string InvalidEmail = "Invalid email address";
        public const string EmailTaken = "Email address is already in use";
        public const string PasswordRequired = "Password is required and must be at least 8 characters";
        public const string RoleInvalid = "Role is invalid";
        public const string RoleRequired = "Role is required";
    }
}
