using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Domain.Models.Products;

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
