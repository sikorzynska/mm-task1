using MentorMate.Restaurant.Business.Services.Interfaces;
using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Data.Misc;
using MentorMate.Restaurant.Data.Repositories.Interfaces;
using MentorMate.Restaurant.Domain.Consts;
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

        public async Task<UserResponse> AddUserAsync(AddUserModel model)
        {
            var result = new UserResponse();
            if(await EmailIsTaken(model.Email))
            {
                result.Result = false;
                result.ResultMessage = Messages.EmailTakenMessage;

                return result;
            }

            if(!RoleIsValid(model.Role))
            {
                result.Result = false;
                result.ResultMessage = Messages.RoleInvalidMessage;

                return result;
            }

            var user = new User
            {
                Name = model.Name,
                Email = model.Email,
            };

            await _userRepository.AddUserAsync(user, model.Password, model.Role);

            result.Result = true;
            result.ResultMessage = Messages.UserCreatedMessage;
            result.Name = model.Name;
            result.Email = model.Email;
            result.Role = model.Role;
            result.Password = model.Password;

            return result;
        }

        public async Task<UserResponse> DeleteUserAsync(string id)
        {
            var result = new UserResponse();
            var user = await _userRepository.GetByIdAsync(id);

            if(user == null)
            {
                result.Result = false;
                result.ResultMessage = Messages.UserNotFoundMessage;

                return result;
            }

            await _userRepository.DeleteUserAsync(user);

            result.Result = true;
            result.ResultMessage = Messages.UserDeletedMessage;

            return result;
        }

        public async Task<IEnumerable<User>> GetAllAsync() =>
            await _userRepository.GetAllAsync();

        public async Task<User> GetByEmailAsync(string email) =>
            await _userRepository.GetByEmailAsync(email);

        public async Task<User> GetByIdAsync(string id) =>
            await _userRepository.GetByIdAsync(id);

        public async Task<UserResponse> UpdateUserAsync(string id, UpdateUserModel model)
        {
            var result = new UserResponse();

            var existingUser = await _userRepository.GetByIdAsync(id);

            if(existingUser == null)
            {
                result.Result = false;
                result.ResultMessage = Messages.UserNotFoundMessage;

                return result;
            }

            if(!string.IsNullOrEmpty(model.Email) && await EmailIsTaken(model.Email))
            {
                result.Result = false;
                result.ResultMessage = Messages.EmailTakenMessage;

                return result;
            }

            if (!string.IsNullOrEmpty(model.Role) && !RoleIsValid(model.Role))
            {
                result.Result = false;
                result.ResultMessage = Messages.RoleInvalidMessage;

                return result;
            }

            existingUser.Name = model.Name ?? model.Name;
            existingUser.Email = model.Email ?? model.Email;

            await _userRepository.UpdateUserAsync(existingUser, model.Password ?? null, model.Role ?? null);

            result.Result = true;
            result.ResultMessage = Messages.UserUpdatedMessage;
            result.Name = existingUser.Name;
            result.Email = existingUser.Email;
            result.Role = await _userRepository.GetRoleAsync(existingUser);
            result.Password = model.Password ?? null;

            return result;
        }

        #region private methods
        private async Task<bool> EmailIsTaken(string email) =>
            await _userRepository.GetByEmailAsync(email) != null;

        private bool RoleIsValid(string role) =>
            role == UserRoles.Admin || role == UserRoles.Waiter;
        #endregion
    }
}

