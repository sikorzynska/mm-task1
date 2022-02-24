using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MentorMate.Restaurant.Data.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly RestaurantDbContext _dbContext;

        public TableRepository(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        //Get all
        public async Task<IEnumerable<Table>> GetAllAsync() =>
            await _dbContext.Tables.ToListAsync();

        //Get by id
        public async Task<Table> GetByIdAsync(int id) =>
            await _dbContext.Tables.FirstOrDefaultAsync(t => t.Id == id);

        //Add
        public async Task AddAsync(Table table)
        {
            await _dbContext.Tables.AddAsync(table);

            await _dbContext.SaveChangesAsync();
        }

        //Update
        public async Task UpdateAsync(Table table)
        {
            _dbContext.Tables.Update(table);

            await _dbContext.SaveChangesAsync();
        }

        //Delete
        public async Task DeleteAsync(Table table)
        {
            _dbContext.Tables.Remove(table);

            await _dbContext.SaveChangesAsync();
        }
    }
}
