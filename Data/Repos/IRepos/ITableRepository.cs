using RestaurantBooking.Models;

namespace RestaurantBooking.Data.Repos.IRepos
{
    public interface ITableRepository
    {
        Task<IEnumerable<Table>>GetAllTablesAsync();
        Task<Table> GetTableByIdAsync(int id);
        Task AddTableAsync(Table table);
        Task UpdateTableAsync(Table table);
        Task DeleteTableAsync(Table table);
    }
}
