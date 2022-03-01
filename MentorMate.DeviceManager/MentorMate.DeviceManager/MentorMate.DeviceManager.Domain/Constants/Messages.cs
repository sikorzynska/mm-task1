namespace MentorMate.DeviceManager.Domain.Constants
{
    public static class Messages
    {
        public const string DeviceCreated = "Device has been created successfully";
        public const string DeviceUpdated = "Device has been updated successfully";
        public const string DeviceDeleted = "Device has been deleted successfully";
        public const string DeviceNotFound = "Device with ID {0} doesn't exist";

        public const string DeviceNameRequired = "Device name is required";
        public const string DeviceModelRequired = "Device model is required";
        public const string DeviceManufacturerRequired = "Device manufacturer is required";
        public const string DeviceReleaseDateRequired = "Device release date is required";

        public const string DeviceNameLength = "Device name cannot exceed 255 characters";
        public const string DeviceModelLength = "Device model cannot exceed 255 characters";
        public const string DeviceManufacturerLength = "Device manufacturer cannot exceed 255 characters";

        public const string DeviceNameTaken = "Device with this name already exists";

        public const string DeviceIdRequired = "ID is required to update a device";
    }
}
