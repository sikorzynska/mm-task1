using System;
namespace MentorMate.Restaurant.Domain.Consts
{
    public static class Messages
    {
        #region general
        public const string ProccessFailMessage = "Failure";
        public const string ProccessSuccessMessage = "Success";
        #endregion

        #region authentication
        public const string LoginErrorMessage = "Invalid email or password";
        #endregion

        #region user
        //General
        public const string UserNotFoundMessage = "User not found";
        public const string UserUpdatedMessage = "User updated successfully";
        public const string UserCreatedMessage = "User created successfully";
        public const string UserDeletedMessage = "User deleted successfully";
        //Name
        public const string NameRequiredMessage = "Name is required";
        public const string NameLengthMessage = "Name must not exceed 100 characters";
        //Email
        public const string EmailRequiredMessage = "Email is required";
        public const string EmailLengthMessage = "Email must not exceed 255 characters";
        public const string InvalidEmailMessage = "Invalid email address";
        public const string EmailTakenMessage = "Email address is already in use";
        //Password
        public const string PasswordRequiredMessage = "Password is required";
        public const string PasswordLengthMessage = "Password must be between 8 and 100 characters long";
        //Role
        public const string RoleRequiredMessage = "Role is required";
        public const string RoleInvalidMessage = "Role is invalid";
        #endregion
    }
}
