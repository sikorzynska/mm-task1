using MentorMate.Restaurant.Data.Entities;

namespace MentorMate.Restaurant.Data.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<ICollection<Order>> GetAllAsync(bool onlyActive = false);
        Task<Order> GetByIdAsync(string id);
        Task CreateAsync(Order order);
        Task DeleteAsync(Order order);
        Task UpdateAsync(Order order);
    }
}
