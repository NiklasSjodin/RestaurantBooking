using RestaurantBooking.Models.DTOs.Table;

namespace RestaurantBooking.Services.IServices
{
    public interface ITableService
    {
        Task<IEnumerable<GetTableDTO>> GetAllTablesAsync();
        Task<GetTableDTO> GetTableByIdAsync(int id);
        Task AddTableAsync(CreateTableDTO createTable);
        Task UpdateTableAsync(UpdateTableDTO updateTable);
        Task DeleteTableAsync(int id);
    }
}
