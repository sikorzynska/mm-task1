using MentorMate.Restaurant.Domain.Models.Products;

namespace MentorMate.Restaurant.Business.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<GeneralProductModel>> GetAllAsync();
        Task<GeneralProductModel> GetByIdAsync(int id);
        Task<ProductResponse> AddAsync(CreateProductModel model);
        Task<ProductResponse> DeleteAsync(int id);
        Task<ProductResponse> UpdateAsync(UpdateProductModel model);
    }
}
