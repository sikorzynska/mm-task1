using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Domain.Models.General;
using MentorMate.Restaurant.Domain.Models.Products;
using MentorMate.Restaurant.Domain.Models.Sorting;

namespace MentorMate.Restaurant.Business.Services.Interfaces
{
    public interface IProductService
    {
        Task<ICollection<Product>> GetAllAsync(ProductSortingModel sort);
        Task<Product> GetByIdAsync(string id);
        Task<Response> CreateAsync(CreateProductModel model);
        Task<Response> DeleteAsync(string id);
        Task<Response> UpdateAsync(string productId, UpdateProductModel model);
    }
}
