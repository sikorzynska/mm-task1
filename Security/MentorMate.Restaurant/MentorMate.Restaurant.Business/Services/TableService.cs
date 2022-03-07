using MentorMate.Restaurant.Business.Services.Interfaces;
using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Data.Entities.Enums;
using MentorMate.Restaurant.Data.Repositories.Interfaces;
using MentorMate.Restaurant.Domain.Consts;
using MentorMate.Restaurant.Domain.Models.General;
using MentorMate.Restaurant.Domain.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace MentorMate.Restaurant.Business.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;

        public TableService(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public Task<Response> AssignWaiterAsync(int tableId, string waiterId)
        {
            throw new NotImplementedException();
        }

        public Task<Response> CreateAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Table>> GetAllAsync() =>
            await _tableRepository.GetAllAsync();

        public async Task<Table> GetByIdAsync(int tableId)
        {
            var result = await _tableRepository.GetByIdAsync(tableId);

            return result;
        }

        public Task<Response> OccupyAsync(int tableId)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> ClearAsync(int tableId)
        {
            var response = new Response();

            var table = await _tableRepository.GetByIdAsync(tableId);

            if(table == null)
            {
                response = new Response(false, Messages.TableNotFound);

                return response;
            }

            if(table.Status != TableStatus.Active)
            {
                response = new Response(false, Messages.TableNotActive);

                return response;
            }

            table.Status = TableStatus.Free;

            table.Orders.ToList().ForEach(x => x.Status = OrderStatus.Complete);

            await _tableRepository.UpdateAsync(table);

            response = new Response(true, Messages.TableCleared);

            return response;
        }

        public Task<Response> RemoveAsync(int tableId)
        {
            throw new NotImplementedException();
        }

        public Task<Response> WaitAsync(int tableId, string waiterId)
        {
            throw new NotImplementedException();
        }

        #region inner functions
        //private async Task<decimal> CalculateTableBill(int tableId)
        //{
        //    var orders = await _orderRepository.GetAll();

        //    var activeOrders = orders.Where(x => x.TableId == tableId && x.Status == OrderStatus.Active).ToList();

        //    var result = activeOrders.SelectMany(x => x.OrderProducts.Select(v => v.ProductPrice * v.ProductCount)).Sum();

        //    return result;
        //}
        #endregion
    }
}
