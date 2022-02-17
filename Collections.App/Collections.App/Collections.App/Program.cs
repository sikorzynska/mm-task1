using Collections.Business.Services;

namespace Collections.App
{
    static class Program
    {
        private static readonly string productsJsonPath = "../../../../Collections.Business/Data/products.json";
        private static readonly string ordersJsonPath = "../../../../Collections.Business/Data/orders.json";
        static void Main()
        {
            IProductService productService = new ProductService(productsJsonPath);
            IOrderService orderService = new OrderService(ordersJsonPath);
            //var products = productService.GetProductsByIngredient("tomato");
            //foreach (var product in products)
            //{
            //    Console.WriteLine(product.ToString());
            //}

            var orders = orderService.GetOrdersByProductName("salad");
            foreach (var order in orders)
            {
                Console.WriteLine(order.ToString());
            }
        }
    }
}
