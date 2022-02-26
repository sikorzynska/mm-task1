namespace MentorMate.Restaurant.Domain.Models.Users
{
    public class UserErrorResponse
    {
        public UserErrorResponse() { }

        public UserErrorResponse(string error)
        {
            Error = error;
        }

        public string Error { get; set; }
    }
}
