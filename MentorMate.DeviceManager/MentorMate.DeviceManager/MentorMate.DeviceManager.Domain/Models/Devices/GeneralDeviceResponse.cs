namespace MentorMate.DeviceManager.Domain.Models.Devices
{
    public class GeneralDeviceResponse
    {
        public GeneralDeviceResponse()
        {
        }

        public GeneralDeviceResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public GeneralDeviceResponse(bool success, string message, GeneralDeviceModel device)
        {
            Success = success;
            Message = message;
            Device = device;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public GeneralDeviceModel Device { get; set; }
    }
}
