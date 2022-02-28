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

        public Task AddAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> AssignWaiterAsync(int tableId, string waiterId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Table>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Table> GetByIdAsync(int tableId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> OccupyAsync(int tableId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PayBillAsync(int tableId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(int tableId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> WaitAsync(int tableId, string waiterId)
        {
            throw new NotImplementedException();
        }
    }
}
