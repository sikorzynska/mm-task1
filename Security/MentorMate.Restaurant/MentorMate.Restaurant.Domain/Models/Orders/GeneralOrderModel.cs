namespace MentorMate.Restaurant.Domain.Models.Orders
{
    public class GeneralOrderModel
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public string Waiter { get; set; }
        public string DateTime { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }
        public ICollection<OrderProductModel> Products { get; set; } = new List<OrderProductModel>();
    }
}
