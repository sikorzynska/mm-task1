using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MentorMate.Restaurant.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RestaurantDbContext _dbContext;

        public UserRepository(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<User>> GetAllAsync() =>
            await _dbContext.Users.ToListAsync();

        public async Task<User> GetByEmailAsync(string email) =>
            await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);

        public async Task<User> GetByNameAsync(string name) =>
            await _dbContext.Users.FirstOrDefaultAsync(x => x.Name == name);
    }
}
