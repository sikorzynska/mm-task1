using Collections.Business.Models;
using Newtonsoft.Json;

namespace Collections.Business.Services
{
    public class OrderService : IOrderService
    {
        //Search by order number - select all matching products from that order
        //Search sold products during a period(hour(s), day(s), month(s), and/or year(s)) - select all matching products ordered by date and time.Do not group the result.
        //Search sold products for the last month - select all sold products for the period and show aggregated quantity and aggregated price for all sales.Group the result - every matching product should exist once into the result and for this product should show the total count and total price of sold products for the period. Keep in mind that the product price could be changed multiple times during the period.
        //Search average orders amount for the last month
        //Search total orders amount per day for the last month

        private IReadOnlyCollection<Order> orders;
        public OrderService(string jsonPath)
        {
            string ordersJson = File.ReadAllText(jsonPath);
            this.orders = JsonConvert.DeserializeObject<Order[]>(ordersJson);
        }
        public int GetAverageOrdersForLastMonth()
        {
            throw new NotImplementedException();
        }

        public ICollection<Order> GetOrdersByProductName(string productName) =>
            orders.Where(x => x.Products.Any(op => op.Product.Name.ToLower().Contains(productName.ToLower())))
            .ToList();

        public ICollection<Product> GetProductsFromOrderViaDate(string dateTime)
        {
            DateTime date = DateTime.TryParse(dateTime, out DateTime d) ? DateTime.Parse(dateTime) : DateTime.UtcNow;
            var resultOrders = this.orders.Where(o => o.DateTime.Date == date.Date).Select(v => v.Products).ToList();
            var resultProducts = new List<Product>();

            foreach (var orderProduct in resultOrders)
            {
                foreach (var product in orderProduct)
                {
                    resultProducts.Add(product.Product);
                }
            }

            return resultProducts;
        }

        public ICollection<Product> GetProductsFromOrderViaId(int orderId)
        {
            var order = orders.FirstOrDefault(o => o.Id == orderId);

            var products = new List<Product>();

            foreach (var product in order.Products)
            {
                products.Add(product.Product);
            }

            return products;
        }

        public ICollection<Product> GetSoldProductsFromLastMonth()
        {
            throw new NotImplementedException();
        }

        public int GetTotalOrdersAmountPerDayForLastMonth()
        {
            throw new NotImplementedException();
        }
    }
}
