using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MentorMate.Restaurant.Data.Repositories
{
    public class ProductRepository : Repository, IProductRepository
    {
        public ProductRepository(RestaurantDbContext _dbContext) : base(_dbContext)
        {
        }

        //Get all
        public async Task<IEnumerable<Product>> GetAllAsync() =>
            await _dbContext.Products.ToListAsync();

        //Get by id
        public async Task<Product> GetByIdAsync(int id) =>
            await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

        //Add
        public async Task AddAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);

            await _dbContext.SaveChangesAsync();
        }

        //Update
        public async Task UpdateAsync(Product product)
        {
            _dbContext.Products.Update(product);

            await _dbContext.SaveChangesAsync();
        }

        //Delete
        public async Task DeleteAsync(Product product)
        {
            _dbContext.Products.Remove(product);

            await _dbContext.SaveChangesAsync();
        }
    }
}
