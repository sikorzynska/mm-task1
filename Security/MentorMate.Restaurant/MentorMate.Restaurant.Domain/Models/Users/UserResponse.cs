using System.Text.Json.Serialization;

namespace MentorMate.Restaurant.Domain.Models.Users
{
    public class UserResponse
    {
        public UserResponse()
        {
        }
        public UserResponse(bool result, string message)
        {
            Result = result;
            Message = message;
        }
        public UserResponse(bool result, string message, GeneralUserModel model)
        {
            Result = result;
            Message = message;
            User = model;
        }

        [JsonPropertyName("result")]
        public bool Result { get; set; }
        [JsonPropertyName("message")]
        public string? Message { get; set; }
        [JsonPropertyName("user")]
        public GeneralUserModel? User { get; set; }
    }
}
