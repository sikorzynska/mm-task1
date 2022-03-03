using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Domain.Models.General;
using MentorMate.Restaurant.Domain.Models.Users;

namespace MentorMate.Restaurant.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync(string currentUserId);
        Task<User> GetByIdAsync(string id);
        Task<User> GetByEmailAsync(string email);
        Task<Response> CreateAsync(CreateUserModel model);
        Task<Response> DeleteAsync(string id);
        Task<Response> UpdateAsync(string userId, UpdateUserModel model);
        Task<string> GetRoleAsync(string userId);
    }
}
