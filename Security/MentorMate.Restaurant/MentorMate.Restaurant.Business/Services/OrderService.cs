using MentorMate.Restaurant.Business.Models;
using MentorMate.Restaurant.Business.Services.Interfaces;
using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Data.Repositories.Interfaces;

namespace MentorMate.Restaurant.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Order>> GetAllAsync() =>
            await _orderRepository.GetAllAsync();

        public async Task<Order> GetByIdAsync(int id) =>
            await _orderRepository.GetByIdAsync(id);

        public async Task CreateOrderAsync(OrderModel model)
        {
            var order = new Order
            {
                Products = await GetProductsAsync(model),
                TableId = model.TableId,
            };

            await _orderRepository.AddAsync(order);
        }

        public async Task<bool> ChangeOrderAsync(int orderId, OrderModel model)
        {
            var existingOrder = await _orderRepository.GetByIdAsync(orderId);

            if(!existingOrder.IsActive || existingOrder.IsServed || existingOrder == null)
            {
                return false;
            }

            var products = await GetProductsAsync(model);

            existingOrder.Products = products;
            existingOrder.TableId = model.TableId;

            await _orderRepository.UpdateAsync(existingOrder);

            return true;
        }

        public async Task<bool> CancelOrderAsync(int id)
        {
            var existingOrder = await _orderRepository.GetByIdAsync(id);

            if (!existingOrder.IsActive || existingOrder.IsServed || existingOrder == null)
            {
                return false;
            }

            existingOrder.IsActive = false;

            await _orderRepository.UpdateAsync(existingOrder);

            return true;
        }

        public async Task<bool> ServeOrderAsync(int orderId)
        {
            var existingOrder = await _orderRepository.GetByIdAsync(orderId);

            if (!existingOrder.IsActive || existingOrder.IsServed || existingOrder == null)
            {
                return false;
            }

            existingOrder.IsServed = true;
            existingOrder.IsActive = false;

            await _orderRepository.UpdateAsync(existingOrder);

            return true;
        }

        private async Task<ICollection<Product>> GetProductsAsync(OrderModel model)
        {
            var products = new List<Product>();

            foreach (var id in model.ProductIds)
            {
                var product = await _productRepository.GetByIdAsync(id);
                products.Add(product);
            }

            return products;
        }
    }
}
