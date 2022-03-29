using MentorMate.Restaurant.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace MentorMate.Restaurant.Data.Entities
{
    public class Table
    {
        [Key]
        public int Id { get; set; }
        public TableStatus Status { get; set; } = TableStatus.Free;
        public int Capacity { get; set; }
        public string? WaiterId { get; set; }
        public User? Waiter { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
