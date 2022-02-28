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

        public async Task<UserResponse> AddUserAsync(CreateUserModel model)
        {
            var result = new UserResponse();

            if(await EmailIsTaken(model.Email))
            {
                result = new UserResponse(false, Messages.EmailTakenMessage);

                return result;
            }

            if(!RoleIsValid(model.Role))
            {
                result = new UserResponse(false, Messages.RoleInvalidMessage);

                return result;
            }

            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PictureURL = model.PictureURL,
                UserName = model.Username,
                Email = model.Email,
            };

            await _userRepository.AddUserAsync(user, model.Password, model.Role);

            result = new UserResponse(
                true,
                Messages.UserCreatedMessage,
                new GeneralUserModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName= user.LastName,
                    Username = user.UserName,
                    Email = user.Email,
                    Role = model.Role,
                });

            return result;
        }

        public async Task<UserResponse> DeleteUserAsync(string id)
        {
            var result = new UserResponse();
            var user = await _userRepository.GetByIdAsync(id);

            if(user == null)
            {
                result = new UserResponse(false, Messages.UserNotFoundMessage);

                return result;
            }

            var userRole = await _userRepository.GetRoleAsync(user);

            result.Result = true;
            result.Message = Messages.UserDeletedMessage;

            result = new UserResponse(
                true,
                Messages.UserDeletedMessage,
                new GeneralUserModel
                {
                    Id = user.Id,
                    FirstName= user.FirstName,
                    LastName = user.LastName,
                    PictureURL = user.PictureURL,
                    Username = user.UserName,
                    Email = user.Email,
                    Role = userRole
                });

            await _userRepository.DeleteUserAsync(user);

            return result;
        }

        public async Task<IEnumerable<GeneralUserModel>> GetAllAsync() 
        {
            var users = await _userRepository.GetAllAsync();

            var result = users.Select(u => new GeneralUserModel
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                PictureURL = u.PictureURL,
                Username= u.UserName,
                Email= u.Email,
                Role = _userRepository.GetRoleAsync(u).Result,
            }).ToList();

            return result;
        }

        public async Task<GeneralUserModel> GetByEmailAsync(string email) 
        {
            var user = await _userRepository.GetByEmailAsync(email);

            if(user == null)
            {
                return null;
            }

            var result = new GeneralUserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PictureURL = user.PictureURL,
                Username = user.UserName,
                Email = user.Email,
                Role = _userRepository.GetRoleAsync(user).Result
            };

            return result;
        }

        public async Task<GeneralUserModel> GetByIdAsync(string id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if(user == null)
            {
                return null;
            }

            var result = new GeneralUserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PictureURL = user.PictureURL,
                Username = user.UserName,
                Email = user.Email,
                Role = _userRepository.GetRoleAsync(user).Result
            };

            return result;
        }

        public async Task<UserResponse> UpdateUserAsync(UpdateUserModel model)
        {
            var result = new UserResponse();

            var existingUser = await _userRepository.GetByIdAsync(model.Id);

            if(existingUser == null)
            {
                result = new UserResponse(false, Messages.UserNotFoundMessage);

                return result;
            }

            if(!string.IsNullOrEmpty(model.Email) && await EmailIsTaken(model.Email))
            {
                result = new UserResponse(false, Messages.EmailTakenMessage);

                return result;
            }

            if (!string.IsNullOrEmpty(model.Role) && !RoleIsValid(model.Role))
            {
                result = new UserResponse(false, Messages.RoleInvalidMessage);

                return result;
            }

            existingUser.FirstName = model.FirstName ?? existingUser.FirstName;
            existingUser.LastName = model.LastName ?? existingUser.LastName;
            existingUser.PictureURL = model.PictureURL ?? existingUser.PictureURL;
            existingUser.UserName = model.Username ?? existingUser.UserName;
            existingUser.Email = model.Email ?? existingUser.Email;

            await _userRepository.UpdateUserAsync(existingUser, model.Password ?? null, model.Role ?? null);

            var userRole = await _userRepository.GetRoleAsync(existingUser);

            result = new UserResponse(
                true,
                Messages.UserUpdatedMessage,
                new GeneralUserModel
                {
                    Id = model.Id,
                    FirstName = existingUser.FirstName,
                    LastName = existingUser.LastName,
                    PictureURL = existingUser.PictureURL,
                    Username = existingUser.UserName,
                    Email = existingUser.Email,
                    Role = userRole,
                });

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

