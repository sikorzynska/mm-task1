using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MentorMate.Restaurant.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly RestaurantDbContext _dbContext;

        public OrderRepository(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        //Get all
        public async Task<IEnumerable<Order>> GetAllAsync() =>
            await _dbContext.Orders.OrderBy(o => o.TableId).ToListAsync();

        //Get by id
        public async Task<Order> GetByIdAsync(int id) =>
            await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);

        //Add
        public async Task AddAsync(Order order)
        {
            await _dbContext.Orders.AddAsync(order);

            await _dbContext.SaveChangesAsync();
        }

        //Update
        public async Task UpdateAsync(Order order)
        {
            _dbContext.Orders.Update(order);

            await _dbContext.SaveChangesAsync();
        }

        //Delete
        public async Task DeleteAsync(Order order)
        {
            _dbContext.Orders.Remove(order);

            await _dbContext.SaveChangesAsync();
        }
    }
}
