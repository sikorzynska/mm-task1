using MentorMate.Restaurant.Domain.Models.Tables;

namespace MentorMate.Restaurant.Business.Services.Interfaces
{
    public interface ITableService
    {
        Task<IEnumerable<GeneralTableModel>> GetAllAsync();
        Task<GeneralTableModel> GetByIdAsync(int tableId);
        Task<TableResponse> CreateAsync();
        Task<TableResponse> RemoveAsync(int tableId);
        Task<TableResponse> OccupyAsync(int tableId);
        Task<TableResponse> PayBillAsync(int tableId);
        Task<TableResponse> AssignWaiterAsync(int tableId, string waiterId);
        Task<TableResponse> WaitAsync(int tableId, string waiterId);
    }
}
