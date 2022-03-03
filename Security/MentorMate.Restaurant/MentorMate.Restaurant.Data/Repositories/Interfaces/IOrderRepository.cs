using MentorMate.Restaurant.Data.Entities;

namespace MentorMate.Restaurant.Data.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        IQueryable<Order> GetAll();
        Task<Order> GetByIdAsync(int id);
        Task CreateAsync(Order order);
        Task DeleteAsync(Order order);
        Task UpdateAsync(Order order);
    }
}
