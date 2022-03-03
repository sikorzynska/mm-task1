using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Domain.Models.Categories;
using MentorMate.Restaurant.Domain.Models.General;

namespace MentorMate.Restaurant.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task<Response> CreateAsync(CreateCategoryModel model);
        Task<Response> DeleteAsync(int id);
        Task<Response> UpdateAsync(int categoryId, UpdateCategoryModel model);
    }
}
