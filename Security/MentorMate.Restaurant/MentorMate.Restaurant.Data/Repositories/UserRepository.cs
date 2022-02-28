using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MentorMate.Restaurant.Data.Repositories
{
    public class UserRepository : Repository, IUserRepository
    {
        private readonly UserManager<User> _userManager;
        public UserRepository(RestaurantDbContext dbContext, UserManager<User> userManager) 
            : base(dbContext)
        {
            _userManager = userManager;
        }

        //Get all
        public async Task<IEnumerable<User>> GetAllAsync() =>
            await _dbContext.Users.ToListAsync();

        //Get by id
        public async Task<User> GetByIdAsync(string id) =>
            await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

        //Get by email
        public async Task<User> GetByEmailAsync(string email) =>
            await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);

        //Add
        public async Task AddUserAsync(User user, string password, string role)
        {
            await _userManager.CreateAsync(user, password);

            await _userManager.AddToRoleAsync(user, role);

            await _dbContext.SaveChangesAsync();
        }
            

        //Update
        public async Task UpdateUserAsync(User user, string password = null, string role = null)
        {
            if (password != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                await _userManager.ResetPasswordAsync(user, token, password);
            }

            if(role != null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, roles);

                await _userManager.AddToRoleAsync(user, role);
            }

            await _userManager.UpdateAsync(user);

            await _dbContext.SaveChangesAsync();
        }

        //Delete
        public async Task DeleteUserAsync(User user) 
        {
            await _userManager.DeleteAsync(user);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<string> GetRoleAsync(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            return roles.FirstOrDefault();
        }
    }
}
