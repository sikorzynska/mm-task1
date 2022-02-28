namespace MentorMate.Restaurant.Domain.Models.Orders
{
    public class OrderProductModel
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
