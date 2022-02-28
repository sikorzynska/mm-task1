using System.Text.Json.Serialization;

namespace MentorMate.Restaurant.Domain.Models.Orders
{
    public class OrderResponse
    {
        public OrderResponse()
        {
        }
        public OrderResponse(bool result, string message)
        {
            Result = result;
            Message = message;
        }
        public OrderResponse(bool result, string message, GeneralOrderModel model)
        {
            Result = result;
            Message = message;
            Order = model;
        }

        [JsonPropertyName("result")]
        public bool Result { get; set; }
        [JsonPropertyName("message")]
        public string? Message { get; set; }
        [JsonPropertyName("order")]
        public GeneralOrderModel? Order { get; set; }
    }
}
