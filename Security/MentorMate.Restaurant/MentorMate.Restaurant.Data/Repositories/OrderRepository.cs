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

        public async Task AddAsync(Order order)
        {
            await _dbContext.Orders.AddAsync(order);

            await _dbContext.SaveChangesAsync();
        }

        public async Task CancelAsync(Order order)
        {
            _dbContext.Orders.Remove(order);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAllAsync() =>
            await _dbContext.Orders.OrderBy(o => o.TableId).ToArrayAsync();

        public async Task<IEnumerable<Order>> GetAllByTableIdAsync(int tableId) =>
            await _dbContext.Orders.Where(o => o.TableId == tableId).ToListAsync();

        public async Task<Order> GetByIdAsync(int id) =>
            await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);

        public async Task ServeAsync(Order order)
        {
            var table = await _dbContext.Tables.FirstOrDefaultAsync(t => t.Id == order.TableId);

            table.Bill += order.TotalPrice;
        }

        public async Task UpdateAsync(Order order)
        {
            _dbContext.Orders.Update(order);

            await _dbContext.SaveChangesAsync();
        }
    }
}
