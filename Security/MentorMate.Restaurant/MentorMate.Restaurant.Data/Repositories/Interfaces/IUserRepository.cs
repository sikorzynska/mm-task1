using MentorMate.Restaurant.Data.Entities;

namespace MentorMate.Restaurant.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(string id);
        Task<User> GetByEmailAsync(string email);
        Task AddUserAsync(User user, string password, string role);
        Task DeleteUserAsync(User user);
        Task UpdateUserAsync(User user, string password = null, string role = null);
        Task<string> GetRoleAsync(User user);
    }
}
