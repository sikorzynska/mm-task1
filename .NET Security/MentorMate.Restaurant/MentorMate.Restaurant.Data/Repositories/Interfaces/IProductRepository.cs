using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Domain.Models.Sorting;

namespace MentorMate.Restaurant.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<ICollection<Product>> GetAllAsync(ProductSortingModel sort);
        Task<Product> GetByIdAsync(string id);
        Task CreateAsync(Product product);
        Task DeleteAsync(Product product);
        Task UpdateAsync(Product product);
    }
}
