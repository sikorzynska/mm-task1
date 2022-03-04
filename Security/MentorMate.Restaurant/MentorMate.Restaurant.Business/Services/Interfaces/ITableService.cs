using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Domain.Models.General;

namespace MentorMate.Restaurant.Business.Services.Interfaces
{
    public interface ITableService
    {
        Task<IEnumerable<Table>> GetAllAsync();
        Task<Table> GetByIdAsync(int tableId);
        Task<Response> CreateAsync();
        Task<Response> RemoveAsync(int tableId);
        Task<Response> OccupyAsync(int tableId);
        Task<Response> ClearAsync(int tableId);
        Task<Response> AssignWaiterAsync(int tableId, string waiterId);
        Task<Response> WaitAsync(int tableId, string waiterId);
    }
}
