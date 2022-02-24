using MentorMate.Restaurant.Data.Entities;

namespace MentorMate.Restaurant.Data.Repositories.Interfaces
{
    public interface ITableRepository
    {
        Task<IEnumerable<Table>> GetAllAsync();
        Task<Table> GetByIdAsync(int id);
        Task AddAsync(Table table);
        Task DeleteAsync(Table table);
        Task UpdateAsync(Table table);

    }
}
