using MentorMate.Restaurant.Data.Entities;

namespace MentorMate.Restaurant.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IQueryable<Product> GetAll();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task DeleteAsync(Product product);
        Task UpdateAsync(Product product);
    }
}
