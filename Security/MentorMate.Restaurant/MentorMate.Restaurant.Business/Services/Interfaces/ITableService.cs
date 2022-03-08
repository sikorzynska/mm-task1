using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Domain.Models.General;
using MentorMate.Restaurant.Domain.Models.Tables;

namespace MentorMate.Restaurant.Business.Services.Interfaces
{
    public interface ITableService
    {
        Task<ICollection<Table>> GetAllAsync();
        Task<Table> GetByIdAsync(int tableId);
        Task<Response> CreateAsync(CreateTableModel model);
        Task<Response> RemoveAsync(int tableId);
        Task<Response> OccupyAsync(int tableId);
        Task<Response> ClearAsync(int tableId);
        Task<Response> AssignWaiterAsync(int tableId, string waiterId);
        Task<Response> WaitAsync(int tableId, string waiterId);
    }
}
