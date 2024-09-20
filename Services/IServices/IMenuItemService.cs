using RestaurantBooking.Models;
using RestaurantBooking.Models.DTOs.MenuItem;

namespace RestaurantBooking.Services.IServices
{
    public interface IMenuItemService
    {
        Task<IEnumerable<GetMenuItemDTO>> GetAllMenuItemsAsync();
        Task<GetMenuItemDTO> GetMenuItemByIdAsync(int id);
        Task AddMenuItemAsync(CreateMenuItemDTO createMenuItem);
        Task UpdateMenuItemAsync(UpdateMenuItemDTO updateMenuItem);
        Task DeleteMenuItemAsync(int id);
    }
}
