using MentorMate.Restaurant.Data.Entities;

namespace MentorMate.Restaurant.Data.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByNameAsync(string name);
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task DeleteAsync(Product product);
        Task UpdateAsync(Product product);
    }
}
