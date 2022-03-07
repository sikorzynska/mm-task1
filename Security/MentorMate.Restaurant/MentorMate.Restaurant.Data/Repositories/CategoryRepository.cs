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
        public async Task<ICollection<Category>> GetAllAsync() => 
            await _dbContext.Categories.Include(x => x.Children).Where(x => x.ParentId == null).ToListAsync();

        //Get by id
        public async Task<Category> GetByIdAsync(string id) =>
            await _dbContext.Categories.Include(x => x.Children).FirstOrDefaultAsync(x => x.Id == id);

        //Add
        public async Task CreateAsync(Category category)
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

        //Update raneg
        public async Task UpdateRangeAsync(ICollection<Category> categories)
        {
            _dbContext.Categories.UpdateRange(categories);

            await _dbContext.SaveChangesAsync();
        }
    }
}
