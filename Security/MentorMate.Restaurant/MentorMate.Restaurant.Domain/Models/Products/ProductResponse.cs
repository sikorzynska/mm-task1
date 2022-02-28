using System;
using System.Text.Json.Serialization;

namespace MentorMate.Restaurant.Domain.Models.Products
{
    public class ProductResponse
    {
        public ProductResponse()
        {
        }
        public ProductResponse(bool result, string message)
        {
            Result = result;
            Message = message;
        }
        public ProductResponse(bool result, string message, GeneralProductModel model)
        {
            Result = result;
            Message = message;
            Product = model;
        }

        [JsonPropertyName("result")]
        public bool Result { get; set; }
        [JsonPropertyName("message")]
        public string? Message { get; set; }
        [JsonPropertyName("product")]
        public GeneralProductModel? Product { get; set; }
    }
}
