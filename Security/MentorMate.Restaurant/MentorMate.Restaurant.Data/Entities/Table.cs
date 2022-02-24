namespace MentorMate.Restaurant.Data.Entities
{
    public class Table
    {
        public int Id { get; set; }
        public int WaiterId { get; set; }
        public User? Waiter { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public decimal Bill { get; set; }
        public bool IsOccupied { get; set; }
    }
}
