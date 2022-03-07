using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Domain.Models.Categories;
using MentorMate.Restaurant.Domain.Models.General;

namespace MentorMate.Restaurant.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ICollection<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(string id);
        Task<Response> CreateAsync(CreateCategoryModel model);
        Task<Response> DeleteAsync(string id);
        Task<Response> UpdateAsync(string categoryId, UpdateCategoryModel model);
    }
}
