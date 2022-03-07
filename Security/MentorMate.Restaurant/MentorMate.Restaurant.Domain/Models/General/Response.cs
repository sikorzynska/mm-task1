namespace MentorMate.Restaurant.Domain.Models.General
{
    public class Response
    {
        public Response()
        {
        }

        public Response(bool success, string message)
        {
            Success = success;
            Message = message;
        }
        public Response(bool success, string message, string id)
        {
            Success = success;
            Message = message;
            EntityId = id;
        }

        public bool Success { get; set; }
        public string? Message { get; set; }
        public virtual string? EntityId { get; set; }
    }
}
