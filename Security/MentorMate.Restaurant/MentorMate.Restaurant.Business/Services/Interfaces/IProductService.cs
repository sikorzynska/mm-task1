using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Domain.Models.General;
using MentorMate.Restaurant.Domain.Models.Products;
using MentorMate.Restaurant.Domain.Models.Sorting;

namespace MentorMate.Restaurant.Business.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync(ProductSortingModel sort);
        Task<Product> GetByIdAsync(int id);
        Task<Response> CreateAsync(CreateProductModel model);
        Task<Response> DeleteAsync(int id);
        Task<Response> UpdateAsync(int productId, UpdateProductModel model);
    }
}
