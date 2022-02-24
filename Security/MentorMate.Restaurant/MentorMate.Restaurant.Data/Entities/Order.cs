using System.ComponentModel.DataAnnotations;

namespace MentorMate.Restaurant.Data.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public int TableId { get; set; }
        public Table? Table { get; set; }
        public decimal TotalPrice => Products.Select(p => p.Price).Sum();
        public bool IsActive { get; set; } = true;
        public bool IsServed { get; set; } = false;

    }
}
