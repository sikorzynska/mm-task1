using MentorMate.Restaurant.Business.Services.Interfaces;
using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Data.Misc;
using MentorMate.Restaurant.Data.Repositories.Interfaces;
using MentorMate.Restaurant.Domain.Models.Users;

namespace MentorMate.Restaurant.Business.Services
{ 
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> AddUserAsync(UserModel model)
        {
            if(await EmailIsTaken(model.Email) || !RoleIsValid(model.Role))
            {
                return false;
            }

            var user = new User
            {
                Name = model.Name,
                Email = model.Email,
            };

            await _userRepository.AddUserAsync(user, model.Password, model.Role);

            return true;
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if(user == null)
            {
                return false;
            }

            await _userRepository.DeleteUserAsync(user);

            return true;
        }

        public async Task<IEnumerable<User>> GetAllAsync() =>
            await _userRepository.GetAllAsync();

        public async Task<User> GetByEmailAsync(string email) =>
            await _userRepository.GetByEmailAsync(email);

        public async Task<User> GetByIdAsync(string id) =>
            await _userRepository.GetByIdAsync(id);

        public async Task<bool> UpdateUserAsync(string id, UserModel model)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);

            if (existingUser == null || await EmailIsTaken(model.Email) || !RoleIsValid(model.Role))
            {
                return false;
            }
        }

        private async Task<bool> EmailIsTaken(string email) =>
            await _userRepository.GetByEmailAsync(email) != null;

        private bool RoleIsValid(string role) =>
            role == UserRoles.Admin || role == UserRoles.Waiter;
    }
}

