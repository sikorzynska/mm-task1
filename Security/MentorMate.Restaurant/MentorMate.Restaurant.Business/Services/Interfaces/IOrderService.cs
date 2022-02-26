using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Domain.Models.Orders;

namespace MentorMate.Restaurant.Business.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int id);
        Task CreateOrderAsync(OrderModel model);
        Task<bool> CancelOrderAsync(int id);
        Task<bool> ChangeOrderAsync(int orderId, OrderModel model);
        Task<bool> ServeOrderAsync(int orderId);
    }
}
