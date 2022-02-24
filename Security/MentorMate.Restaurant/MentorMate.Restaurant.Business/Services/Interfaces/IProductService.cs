using MentorMate.Restaurant.Business.Models;
using MentorMate.Restaurant.Data.Entities;

namespace MentorMate.Restaurant.Business.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(ProductModel model);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(int productId, ProductModel model);
    }
}
