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
        }
    }
}
