using MentorMate.Restaurant.Business.Services.Interfaces;
using MentorMate.Restaurant.Data.Entities.Enums;
using MentorMate.Restaurant.Data.Repositories.Interfaces;
using MentorMate.Restaurant.Domain.Models.Tables;

namespace MentorMate.Restaurant.Business.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;
        private readonly IOrderRepository _orderRepository;

        public TableService(ITableRepository tableRepository,
            IOrderRepository orderRepository)
        {
            _tableRepository = tableRepository;
            _orderRepository = orderRepository;
        }

        public Task<TableResponse> AssignWaiterAsync(int tableId, string waiterId)
        {
            throw new NotImplementedException();
        }

        public Task<TableResponse> CreateAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GeneralTableModel>> GetAllAsync()
        {
            var tables = await _tableRepository.GetAllAsync();

            var result = tables.Select(x => new GeneralTableModel
            {
                Id = x.Id,
                Status = x.Status.ToString(),
                Capacity = x.Capacity,
                Waiter = x.Status == TableStatus.Active
                ? x.Waiter.FirstName + " " + x.Waiter.LastName
                : "N/A",
                Bill = x.Status == TableStatus.Active
                ? CalculateTableBill(x.Id).Result.ToString()
                : "0 BGN",
            }).ToList();

            return result;
        }

        public Task<GeneralTableModel> GetByIdAsync(int tableId)
        {
            throw new NotImplementedException();
        }

        public Task<TableResponse> OccupyAsync(int tableId)
        {
            throw new NotImplementedException();
        }

        public Task<TableResponse> PayBillAsync(int tableId)
        {
            throw new NotImplementedException();
        }

        public Task<TableResponse> RemoveAsync(int tableId)
        {
            throw new NotImplementedException();
        }

        public Task<TableResponse> WaitAsync(int tableId, string waiterId)
        {
            throw new NotImplementedException();
        }

        #region inner functions
        private async Task<decimal> CalculateTableBill(int tableId)
        {
            var orders = await _orderRepository.GetAllAsync();

            var activeOrders = orders.Where(x => x.TableId == tableId && x.Status == OrderStatus.Active).ToList();

            var result = activeOrders.SelectMany(x => x.OrderProducts.Select(v => v.ProductPrice * v.ProductCount)).Sum();

            return result;
        }
        #endregion
    }
}
