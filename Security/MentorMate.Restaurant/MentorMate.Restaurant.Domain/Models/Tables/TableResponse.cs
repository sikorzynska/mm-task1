using System.Text.Json.Serialization;

namespace MentorMate.Restaurant.Domain.Models.Tables
{
    public class TableResponse
    {
        public TableResponse()
        {
        }
        public TableResponse(bool result, string message)
        {
            Result = result;
            Message = message;
        }
        public TableResponse(bool result, string message, GeneralTableModel model)
        {
            Result = result;
            Message = message;
            Table = model;
        }

        [JsonPropertyName("result")]
        public bool Result { get; set; }
        [JsonPropertyName("message")]
        public string? Message { get; set; }
        [JsonPropertyName("table")]
        public GeneralTableModel? Table { get; set; }
    }
}
