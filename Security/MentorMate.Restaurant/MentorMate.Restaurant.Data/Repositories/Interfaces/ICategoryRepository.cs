using MentorMate.Restaurant.Data.Entities;

namespace MentorMate.Restaurant.Data.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetAll();
        Task<Category> GetByIdAsync(int id);
        Task CreateAsync(Category category);
        Task DeleteAsync(Category category);
        Task UpdateAsync(Category category);
    }
}
