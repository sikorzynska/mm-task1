using Microsoft.AspNetCore.Identity;

namespace MentorMate.Restaurant.Data.Entities
{
    public class User : IdentityUser
    {
        public ICollection<Table>? Tables { get; set; } = new List<Table>();
    }
}
