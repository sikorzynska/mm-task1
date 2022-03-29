using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Domain.Models.General;
using MentorMate.Restaurant.Domain.Models.Orders;

namespace MentorMate.Restaurant.Business.Services.Interfaces
{
    public interface IOrderService
    {
        Task<ICollection<Order>> GetAllAsync(bool onlyActive = false);
        Task<Order> GetByIdAsync(string id);
        Task<Response> CreateAsync(string waiterId, CreateOrderModel model);
        Task<Response> DeleteAsync(string id);
        Task<Response> CompleteAsync(string waiterId, string orderId, bool isAdmin = false);
    }
}
