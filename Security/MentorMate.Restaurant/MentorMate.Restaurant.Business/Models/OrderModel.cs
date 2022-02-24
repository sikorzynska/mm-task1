namespace MentorMate.Restaurant.Business.Models
{
    public class OrderModel
    {
        public ICollection<int> ProductIds { get; set; } = new List<int>();
        public int TableId { get; set; }
    }
}
