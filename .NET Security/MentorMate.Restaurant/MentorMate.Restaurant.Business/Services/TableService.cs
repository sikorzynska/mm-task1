using MentorMate.Restaurant.Business.Services.Interfaces;
using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Data.Entities.Enums;
using MentorMate.Restaurant.Data.Repositories.Interfaces;
using MentorMate.Restaurant.Domain.Consts;
using MentorMate.Restaurant.Domain.Models.General;
using MentorMate.Restaurant.Domain.Models.Tables;

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

        public async Task<Response> CreateAsync(CreateTableModel model)
        {
            var response = new Response();

            var tables = await _tableRepository.GetAllAsync();

            if(tables.Count() >= 20)
            {
                response = new Response(false, Messages.TablesCapacityReached);

                return response;
            }

            var table = new Table
            {
                Capacity = model.Capacity,
            };

            await _tableRepository.CreateAsync(table);

            response = new Response(true, Messages.TableCreated, table.Id.ToString());

            return response;
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
    }
}
