using MentorMate.Restaurant.Business.Models;
using MentorMate.Restaurant.Data.Entities;

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
