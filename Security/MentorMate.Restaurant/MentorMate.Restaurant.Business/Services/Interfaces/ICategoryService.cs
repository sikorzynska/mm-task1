using MentorMate.Restaurant.Domain.Models.Categories;

namespace MentorMate.Restaurant.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<GeneralCategoryModel>> GetAllAsync();
        Task<GeneralCategoryModel> GetByIdAsync(int id);
        Task<CategoryResponse> AddAsync(CreateCategoryModel model);
        Task<CategoryResponse> DeleteAsync(int id);
        Task<CategoryResponse> UpdateAsync(UpdateCategoryModel model);
    }
}
