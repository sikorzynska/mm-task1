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
        //Picture
        public const string ImageUrlInvalid = "Invalid image url";
        //Username
        public const string UsernameRequiredMessage = "Username is required";
        public const string UsernameLengthMessage = "Username must not exceed 100 characters";
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

        #region category
        //General
        public const string CategoryCreatedMessage = "Category successfully created";
        public const string CategoryUpdatedMessage = "Category successfully updated";
        public const string CategoryDeletedMessage = "Category successfully deleted";
        public const string CategoryNotFound = "Category not found";
        //Name
        public const string CategoryNameRequired = "Category name is required";
        public const string CategoryNameLength = "Category name must not exceed 100 characters";
        #endregion

        #region product
        //General
        public const string ProductCreated = "Product successfully created";
        public const string ProductUpdated = "Product successfully updated";
        public const string ProductDeleted = "Product successfully deleted";
        public const string ProductNotFound = "Product not found";
        //Name
        public const string ProductNameRequired = "Product name is required";
        public const string ProductNameLength = "Product name must not exceed 100 characters";
        //Price
        public const string ProductPriceRange = "Product price must be between 0,01 and 10000,00";
        public const string ProductPriceRequired = "Product price is required";
        //Category
        public const string ProductCategoryRequired = "Product category id is required";
        public const string ProductCategoryInvalid = "Product category is invalid";
        #endregion

        #region order
        //General
        public const string OrderCreated = "Order successfully created";
        public const string OrderUpdated = "Order successfully updated";
        public const string OrderDeleted = "Order successfully deleted";
        public const string OrderCompleted = "Order successfully completed";
        public const string OrderNotFound = "Order not found";
        public const string OrderAlreadyCompleted = "Order is already completed";
        public const string OrderUnauthorized = "You are not authorized to make changes to this order";
        //Table
        public const string OrderTableIdRequired = "Table id is required to create an order";
        //Products
        public const string OrderProductsRequired = "You need at least one product to create an order";
        public const string OrderInvalidProductId = "{0} is not a valid product ID";
        #endregion

        #region table
        public const string InvalidTableId = "Invalid table ID";
        #endregion
    }
}
