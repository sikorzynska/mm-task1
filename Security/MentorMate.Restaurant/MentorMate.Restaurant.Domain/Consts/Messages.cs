namespace MentorMate.Restaurant.Domain.Consts
{
    public static class Messages
    {
        #region authentication
        public const string LoginError = "Invalid email or password";
        #endregion

        #region user
        //General
        public const string UserNotFound = "User not found";
        public const string UserUpdated = "User updated successfully";
        public const string UserCreated = "User created successfully";
        public const string UserDeleted = "User deleted successfully";
        //Name
        public const string UserNameRequired = "Name is required";
        public const string UserNameLength = "Name must not exceed 100 characters";
        //Picture
        public const string UserImageUrlInvalid = "Invalid image url";
        //Username
        public const string UserUsernameRequired = "Username is required";
        public const string UserUsernameLength = "Username must not exceed 100 characters";
        //Email
        public const string UserEmailRequired = "Email is required";
        public const string UserEmailLength = "Email must not exceed 255 characters";
        public const string UserEmailInvalid = "Invalid email address";
        public const string UserEmailTaken = "Email address is already in use";
        //Password
        public const string UserPasswordRequired = "Password is required";
        public const string UserPasswordLength = "Password must be between 8 and 100 characters long";
        //Role
        public const string UserRoleRequired = "Role is required";
        public const string UserRoleInvalid = "Role is invalid";
        #endregion

        #region category
        //General
        public const string CategoryCreated = "Category successfully created";
        public const string CategoryUpdated = "Category successfully updated";
        public const string CategoryDeleted = "Category successfully deleted";
        public const string CategoryNotFound = "Category not found";
        public const string CategoryParentInvalidId = "Invalid parent category ID";
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
        //General
        public const string TableCreated = "Table successfully created";
        public const string TableUpdated = "Table successfully updated";
        public const string TableDeleted = "Table successfully deleted";
        public const string TableNotFound = "Table not found";
        public const string TableNotActive = "Table is not active/occupied";
        public const string TableNoOrders = "Table doesn't have any orders";
        public const string TableCleared = "Table successfully cleared";
        //Id
        public const string TableInvalidId = "Invalid table ID";
        #endregion
    }
}
