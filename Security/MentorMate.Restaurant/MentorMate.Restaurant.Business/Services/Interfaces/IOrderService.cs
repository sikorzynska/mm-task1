using MentorMate.Restaurant.Domain.Models.Orders;

namespace MentorMate.Restaurant.Business.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<GeneralOrderModel>> GetAllAsync();
        Task<IEnumerable<GeneralOrderModel>> GetActiveAsync();
        Task<GeneralOrderModel> GetByIdAsync(int id);
        Task<OrderResponse> CreateAsync(string waiterId, CreateOrderModel model);
        Task<OrderResponse> DeleteAsync(int id);
        Task<OrderResponse> CompleteAsync(string waiterId, int orderId, bool isAdmin = false);
    }
}
