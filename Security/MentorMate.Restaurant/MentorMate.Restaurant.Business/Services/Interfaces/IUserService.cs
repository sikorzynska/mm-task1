using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Domain.Models.Users;

namespace MentorMate.Restaurant.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(string id);
        Task<User> GetByEmailAsync(string email);
        Task<UserResponse> AddUserAsync(AddUserModel model);
        Task<UserResponse> DeleteUserAsync(string id);
        Task<UserResponse> UpdateUserAsync(string id, UpdateUserModel model);
    }
}
