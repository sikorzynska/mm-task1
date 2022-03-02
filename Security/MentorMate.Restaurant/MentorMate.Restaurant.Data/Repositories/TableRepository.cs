﻿using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MentorMate.Restaurant.Data.Repositories
{
    public class TableRepository : Repository, ITableRepository
    {
        public TableRepository(RestaurantDbContext dbContext) : base(dbContext)
        {
        }

        //Get all
        public async Task<IEnumerable<Table>> GetAllAsync() =>
            await _dbContext.Tables.Include(x => x.Waiter).Include(x => x.Orders).ToListAsync();

        //Get by id
        public async Task<Table> GetByIdAsync(int id) =>
            await _dbContext.Tables.Include(x => x.Waiter).Include(x => x.Orders).FirstOrDefaultAsync(t => t.Id == id);

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
