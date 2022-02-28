using MentorMate.Restaurant.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MentorMate.Restaurant.Data.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public int TableId { get; set; }
        [ForeignKey("TableId")]
        public Table Table { get; set; }
        public string WaiterId { get; set; }
        [ForeignKey("WaiterId")]
        public User Waiter { get; set; }
        public Status Status { get; set; } = Status.Active;
        public decimal TotalPrice => Products.Select(p => p.Price).Sum();

    }
}
