namespace MentorMate.Restaurant.Domain.Models.Orders
{
    public class OrderModel
    {
        public ICollection<int> ProductIds { get; set; } = new List<int>();
        public int TableId { get; set; }
    }
}
