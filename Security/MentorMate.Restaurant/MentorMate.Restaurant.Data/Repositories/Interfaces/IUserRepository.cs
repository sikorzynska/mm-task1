using MentorMate.Restaurant.Data.Entities;

namespace MentorMate.Restaurant.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> GetAll();
        Task<User> GetByIdAsync(string id);
        Task<User> GetByEmailAsync(string email);
        Task CreateAsync(User user, string password, string role);
        Task DeleteAsync(User user);
        Task UpdateAsync(User user, string password = null, string role = null);
        Task<string> GetRoleAsync(User user);
    }
}
