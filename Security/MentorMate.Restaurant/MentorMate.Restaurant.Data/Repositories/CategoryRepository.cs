using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MentorMate.Restaurant.Data.Repositories
{
    public class CategoryRepository : Repository, ICategoryRepository
    {
        public CategoryRepository(RestaurantDbContext dbContext) : base(dbContext)
        {
        }

        //Get all
        public async Task<IEnumerable<Category>> GetAllAsync() =>
            await _dbContext.Categories.ToListAsync();

        //Get by id
        public async Task<Category> GetByIdAsync(int id) =>
            await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

        //Add
        public async Task AddAsync(Category category)
        {
            await _dbContext.Categories.AddAsync(category);

            await _dbContext.SaveChangesAsync();
        }

        //Update
        public async Task UpdateAsync(Category category)
        {
            _dbContext.Categories.Update(category);

            await _dbContext.SaveChangesAsync();
        }

        //Delete
        public async Task DeleteAsync(Category category)
        {
            _dbContext.Categories.Remove(category);

            await _dbContext.SaveChangesAsync();
        }
    }
}
