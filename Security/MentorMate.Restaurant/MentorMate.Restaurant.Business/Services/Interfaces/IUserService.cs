using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Domain.Models.Users;

namespace MentorMate.Restaurant.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(string id);
        Task<User> GetByEmailAsync(string email);
        Task<bool> AddUserAsync(UserModel model);
        Task<bool> DeleteUserAsync(UserModel model);
        Task<bool> UpdateUserAsync(string id, UserModel model);
    }
}
