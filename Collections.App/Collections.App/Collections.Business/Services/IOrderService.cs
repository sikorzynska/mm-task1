using Collections.Business.Models;

namespace Collections.Business.Services
{
    public interface IOrderService
    {
        public ICollection<Order> GetOrdersByProductName(string productName);
        public ICollection<Product> GetProductsFromOrderViaId(int orderId);
        public ICollection<Product> GetProductsFromOrderViaDate(DateTime dateTime);
        public ICollection<Product> GetSoldProductsFromLastMonth();
        public int GetAverageOrdersForLastMonth();
        public IDictionary<string, int> GetTotalOrdersAmountPerDayForLastMonth();
    }
}
