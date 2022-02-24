using MentorMate.Restaurant.Business.Services.Interfaces;
using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Data.Repositories.Interfaces;

namespace MentorMate.Restaurant.Business.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;

        public TableService(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public async Task<IEnumerable<Table>> GetAllAsync() =>
            await _tableRepository.GetAllAsync();

        public async Task<Table> GetByIdAsync(int tableId) =>
            await _tableRepository.GetByIdAsync(tableId);

        public async Task AddAsync() =>
            await _tableRepository.AddAsync(new Table());

        public async Task<bool> OccupyAsync(int tableId)
        {
            var table = await _tableRepository.GetByIdAsync(tableId);

            if(table.IsOccupied || table == null)
            {
                return false;
            }

            table.IsOccupied = true;

            return true;
        }

        public async Task<bool> PayBillAsync(int tableId)
        {
            var table = await _tableRepository.GetByIdAsync(tableId);

            if(table == null || !table.IsOccupied || table.Bill <= 0)
            {
                return false;
            }

            table.Orders = new List<Order>();
            table.IsOccupied = false;

            return true;
        }

        public async Task<bool> RemoveAsync(int tableId)
        {
            var table = await _tableRepository.GetByIdAsync(tableId);

            if(table == null)
            {
                return false;
            }

            await _tableRepository.DeleteAsync(table);

            return true;
        }

        public async Task<bool> AssignWaiterAsync(int tableId, string waiterId)
        {
            var table = await _tableRepository.GetByIdAsync(tableId);

            if(table == null)
            {
                return false;
            }

            table.WaiterId = waiterId;

            await _tableRepository.UpdateAsync(table);

            return true;
        }

        public async Task<bool> WaitAsync(int tableId, string waiterId)
        {
            var table = await _tableRepository.GetByIdAsync(tableId);

            if (table == null || table.WaiterId != null)
            {
                return false;
            }

            table.WaiterId = waiterId;

            await _tableRepository.UpdateAsync(table);

            return true;
        }
    }
}
