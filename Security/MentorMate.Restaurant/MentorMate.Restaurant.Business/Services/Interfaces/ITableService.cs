using MentorMate.Restaurant.Data.Entities;

namespace MentorMate.Restaurant.Business.Services.Interfaces
{
    public interface ITableService
    {
        Task<IEnumerable<Table>> GetAllAsync();
        Task<Table> GetByIdAsync(int tableId);
        Task AddAsync();
        Task<bool> RemoveAsync(int tableId);
        Task<bool> OccupyAsync(int tableId);
        Task<bool> PayBillAsync(int tableId);
        Task<bool> AssignWaiterAsync(int tableId, string waiterId);
        Task<bool> WaitAsync(int tableId, string waiterId);
    }
}
