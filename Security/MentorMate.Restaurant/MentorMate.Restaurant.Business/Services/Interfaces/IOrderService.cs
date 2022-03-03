using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Domain.Models.General;
using MentorMate.Restaurant.Domain.Models.Orders;

namespace MentorMate.Restaurant.Business.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<IEnumerable<Order>> GetActiveAsync();
        Task<Order> GetByIdAsync(int id);
        Task<Response> CreateAsync(string waiterId, CreateOrderModel model);
        Task<Response> DeleteAsync(int id);
        Task<Response> CompleteAsync(string waiterId, int orderId, bool isAdmin = false);
    }
}
