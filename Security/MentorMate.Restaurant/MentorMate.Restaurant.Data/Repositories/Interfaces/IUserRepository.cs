using MentorMate.Restaurant.Data.Entities;

namespace MentorMate.Restaurant.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByNameAsync(string name);
        Task<User> GetByEmailAsync(string email);
    }
}
