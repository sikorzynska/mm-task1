using MentorMate.Restaurant.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentorMate.Restaurant.Data.Repositories.Interfaces
{
    public interface ITableRepository
    {
        Task<IEnumerable<Table>> GetAllAsync();
        Task<IEnumerable<Table>> GetAllByTableIdAsync(int tableId);
        Task<Table> GetByIdAsync(int id);
        Task AddAsync(Table table);
        Task RemoveAsync(Table table);
        Task AssignWaiterAsync(Table table, User waiter);
        Task ChangeWaiterAsync(Table table, User waiter);
        Task PayBillAsync(Table table);

    }
}
