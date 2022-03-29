using MentorMate.Restaurant.Business.Services.Interfaces;
using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Data.Misc;
using MentorMate.Restaurant.Data.Repositories.Interfaces;
using MentorMate.Restaurant.Domain.Consts;
using MentorMate.Restaurant.Domain.Models.General;
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

        public async Task<Response> CreateAsync(CreateUserModel model)
        {
            var response = new Response();

            if(await EmailTakenAsync(model.Email))
            {
                response = new Response(false, Messages.UserEmailTaken);

                return response;
            }

            if(!RoleIsValid(model.Role))
            {
                response = new Response(false, Messages.UserRoleInvalid);

                return response;
            }

            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PictureURL = model.PictureURL,
                UserName = model.Username,
                Email = model.Email,
            };

            if(model.Role == UserRoles.Waiter)
            {
                user.Tables = new List<Table>();
            }

            await _userRepository.CreateAsync(user, model.Password, model.Role);

            response = new Response(true, Messages.UserCreated, user.Id);

            return response;
        }

        public async Task<Response> DeleteAsync(string id)
        {
            var response = new Response();

            var user = await _userRepository.GetByIdAsync(id);

            if(user == null)
            {
                response = new Response(false, Messages.UserNotFound);

                return response;
            }

            await _userRepository.DeleteAsync(user);

            response = new Response(true, Messages.UserDeleted);

            return response;
        }

        public async Task<ICollection<User>> GetAllAsync(string currentUserId) 
        {
            var result = await _userRepository.GetAllAsync(currentUserId);

            return result;
        }

        public async Task<User> GetByEmailAsync(string email) 
        {
            var result = await _userRepository.GetByEmailAsync(email);

            return result;
        }

        public async Task<User> GetByIdAsync(string id)
        {
            var result = await _userRepository.GetByIdAsync(id);

            return result;
        }

        public async Task<Response> UpdateAsync(string userId, UpdateUserModel model)
        {
            var response = new Response();

            var user = await _userRepository.GetByIdAsync(userId);

            if(user == null)
            {
                response = new Response(false, Messages.UserNotFound);

                return response;
            }

            if(!string.IsNullOrEmpty(model.Email) && await EmailTakenAsync(model.Email))
            {
                response = new Response(false, Messages.UserEmailTaken);

                return response;
            }

            if (!string.IsNullOrEmpty(model.Role) && !RoleIsValid(model.Role))
            {
                response = new Response(false, Messages.UserRoleInvalid);

                return response;
            }

            user.FirstName = model.FirstName ?? user.FirstName;
            user.LastName = model.LastName ?? user.LastName;
            user.PictureURL = model.PictureURL ?? user.PictureURL;
            user.UserName = model.Username ?? user.UserName;
            user.Email = model.Email ?? user.Email;

            await _userRepository.UpdateAsync(user, model.Password ?? null, model.Role ?? null);

            var userRole = await _userRepository.GetRoleAsync(user);

            response = new Response(true, Messages.UserUpdated);

            return response;
        }

        public async Task<string> GetRoleAsync(string userId) 
        {
            var user = await _userRepository.GetByIdAsync(userId);

            var role = await _userRepository.GetRoleAsync(user);

            return role;
        }

        #region private methods
        private async Task<bool> EmailTakenAsync(string email) =>
            await _userRepository.GetByEmailAsync(email) != null;

        private bool RoleIsValid(string role) =>
            role == UserRoles.Admin || role == UserRoles.Waiter;
        #endregion
    }
}

