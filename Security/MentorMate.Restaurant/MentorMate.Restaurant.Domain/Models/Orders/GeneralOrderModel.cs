using MentorMate.Restaurant.Domain.Models.Products;
using MentorMate.Restaurant.Domain.Models.Users;

namespace MentorMate.Restaurant.Domain.Models.Orders
{
    public class GeneralOrderModel
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public GeneralUserModel Waiter { get; set; }
        public DateTime DateTime { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }
        public ICollection<OrderProductModel> Products { get; set; } = new List<OrderProductModel>();
    }
}
