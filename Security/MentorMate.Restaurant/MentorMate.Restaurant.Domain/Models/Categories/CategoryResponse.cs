using System.Text.Json.Serialization;

namespace MentorMate.Restaurant.Domain.Models.Categories
{
    public class CategoryResponse
    {
        public CategoryResponse()
        {
        }
        public CategoryResponse(bool result, string message)
        {
            Result = result;
            Message = message;
        }
        public CategoryResponse(bool result, string message, GeneralCategoryModel model)
        {
            Result = result;
            Message = message;
            Category = model;
        }

        [JsonPropertyName("result")]
        public bool Result { get; set; }
        [JsonPropertyName("message")]
        public string? Message { get; set; }
        [JsonPropertyName("category")]
        public GeneralCategoryModel? Category { get; set; }
    }
}
