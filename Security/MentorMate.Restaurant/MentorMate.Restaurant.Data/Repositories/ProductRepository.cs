using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MentorMate.Restaurant.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly RestaurantDbContext _dbContext;

        public ProductRepository(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task AddAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _dbContext.Remove(product);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync() =>
            await _dbContext.Products.ToListAsync();

        public async Task<Product> GetByIdAsync(int id) =>
            await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Product> GetByNameAsync(string name) =>
            await _dbContext.Products.FirstOrDefaultAsync(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

        public async Task UpdateAsync(Product product)
        {
            _dbContext.Products.Update(product);

            await _dbContext.SaveChangesAsync();
        }
    }
}
