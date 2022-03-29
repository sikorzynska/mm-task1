using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Data.Entities.Enums;
using MentorMate.Restaurant.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MentorMate.Restaurant.Data.Repositories
{
    public class OrderRepository : Repository, IOrderRepository
    {
        public OrderRepository(RestaurantDbContext dbContext) : base(dbContext)
        {
        }

        //Get all
        public async Task<ICollection<Order>> GetAllAsync(bool onlyActive = false)
        {
            var result = new List<Order>();

            if(onlyActive)
            {
                result = await _dbContext.Orders
                    .Where(x => x.Status == OrderStatus.Active)
                    .Include(x => x.Waiter)
                    .Include(x => x.OrderProducts)
                    .ThenInclude(x => x.Product)
                    .ToListAsync();

                return result;
            }

            result = await _dbContext.Orders
                .Include(x => x.Waiter)
                .Include(x => x.OrderProducts)
                .ThenInclude(x => x.Product)
                .ToListAsync();

            return result;
        }

        //Get by id
        public async Task<Order> GetByIdAsync(string id) =>
            await _dbContext.Orders
            .Include(x => x.Waiter)
            .Include(x => x.OrderProducts)
            .ThenInclude(x => x.Product)
            .FirstOrDefaultAsync(o => o.Id == id);

        //Add
        public async Task CreateAsync(Order order)
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
