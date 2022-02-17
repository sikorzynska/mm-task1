using Collections.Business.Models;
using Newtonsoft.Json;
using System.Globalization;

namespace Collections.Business.Services
{
    public class OrderService : IOrderService
    {
        private IReadOnlyCollection<Order> _orders;
        public OrderService(string jsonPath)
        {
            string ordersJson = File.ReadAllText(jsonPath);
            this._orders = JsonConvert.DeserializeObject<Order[]>(ordersJson);
        }

        public ICollection<Order> GetOrdersByProductName(string productName) =>
            _orders.Where(x => x.Products.Any(op => op.Product.Name.ToLower().Contains(productName.ToLower())))
            .ToList();

        public ICollection<Product> GetProductsFromOrderViaDate(DateTime dateTime)
        {
            var test = _orders
                .Where(o => o.DateTime.Date == dateTime.Date)
                .Select(v => v.Products)
                .Select(x => x.Select(x => x.Product))
                .ToList();

            var resultOrders = this._orders.Where(o => o.DateTime.Date == dateTime.Date ).Select(v => v.Products).ToList();
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

        public int GetAverageOrdersForLastMonth()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.AddMonths(-1).Month;
            int day = DateTime.Now.Day;
            DateTime date = new DateTime(year, month, day);

            int lastMonthTotalOrders = _orders.Count(o => o.DateTime.Year == date.Year && o.DateTime.Month == date.Month);

            return lastMonthTotalOrders;
        }

        public ICollection<Product> GetProductsFromOrderViaId(int orderId)
        {
            var order = _orders.FirstOrDefault(o => o.Id == orderId);

            var products = new List<Product>();

            foreach (var product in order.Products)
            {
                products.Add(product.Product);
            }

            return products;
        }

        public ICollection<Product> GetSoldProductsFromLastMonth()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.AddMonths(-1).Month;
            int day = DateTime.Now.Day;
            DateTime date = new DateTime(year, month, day);

            var resultOrders = _orders.Where(o => o.DateTime.Year == date.Year && o.DateTime.Month == date.Month)
                .Select(x => x.Products)
                .ToList();
            var resultProducts = new List<Product>();

            foreach (var op in resultOrders)
            {
                foreach (var product in op)
                {
                    resultProducts.Add(product.Product);
                }
            }

            return resultProducts;

        }

        public IDictionary<string, int> GetTotalOrdersAmountPerDayForLastMonth()
        {
            var dates = GetDatesFromLastMonth();

            var dict = new Dictionary<string, int>();
            foreach (var date in dates)
            {
                var totalOrdersForDay = _orders.Count(o => o.DateTime.Date == date.Date);
                dict.Add(date.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture), totalOrdersForDay);
            }

            return dict;
        }

        public static List<DateTime> GetDatesFromLastMonth()
        {
            int lastMonth = DateTime.Now.AddMonths(-1).Month;
            int year = DateTime.Now.Year;
            return Enumerable.Range(1, DateTime.DaysInMonth(year, lastMonth))
                             .Select(day => new DateTime(year, lastMonth, day))
                             .ToList();
        }
    }
}
