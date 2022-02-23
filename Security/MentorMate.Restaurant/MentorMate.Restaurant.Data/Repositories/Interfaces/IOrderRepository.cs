using MentorMate.Restaurant.Data.Entities;

namespace MentorMate.Restaurant.Data.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<IEnumerable<Order>> GetAllByTableIdAsync(int tableId);
        Task<Order> GetByIdAsync(int id);
        Task AddAsync(Order order);
        Task ServeAsync(Order order);
        Task CancelAsync(Order order);
        Task UpdateAsync(Order order);
    }
}
