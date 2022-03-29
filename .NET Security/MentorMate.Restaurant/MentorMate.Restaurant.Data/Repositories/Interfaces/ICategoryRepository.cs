using MentorMate.Restaurant.Data.Entities;

namespace MentorMate.Restaurant.Data.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(string id);
        Task CreateAsync(Category category);
        Task DeleteAsync(Category category);
        Task UpdateAsync(Category category);
        Task UpdateRangeAsync(ICollection<Category> categories);
    }
}
