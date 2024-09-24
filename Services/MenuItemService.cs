using RestaurantBooking.Data.Repos.IRepos;
using RestaurantBooking.Models;
using RestaurantBooking.Models.DTOs.MenuItem;
using RestaurantBooking.Services.IServices;
using System.Reflection;

namespace RestaurantBooking.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public MenuItemService(IMenuItemRepository menuItemRepo)
        {
            _menuItemRepository = menuItemRepo;
        }

        public async Task<IEnumerable<GetMenuItemDTO>> GetAllMenuItemsAsync()
        {
            var menuItem = await _menuItemRepository.GetAllMenuItemsAsync();
            var menuItemsList = menuItem.Select(mi => new GetMenuItemDTO
            {
                ItemId = mi.ItemId,
                Name = mi.Name,
                Price = mi.Price,
                IsAvailable = mi.IsAvailable,
            }).ToList();
            return menuItemsList;
        }

        public async Task<GetMenuItemDTO> GetMenuItemByIdAsync(int id)
        {
            var foundMenuItem = await _menuItemRepository.GetMenuItemByIdAsync(id);
            var menuItem = new GetMenuItemDTO
            {
                ItemId = foundMenuItem.ItemId,
                Name = foundMenuItem.Name,
                Price = foundMenuItem.Price,
                IsAvailable = foundMenuItem.IsAvailable,
            };
            return menuItem;

        }
        public async Task AddMenuItemAsync(CreateMenuItemDTO createMenuItem)
        {
            var newMenuItem = new MenuItem
            {
                Name = createMenuItem.Name,
                Price = createMenuItem.Price,
                IsAvailable = createMenuItem.IsAvailable,
            };

            await _menuItemRepository.AddMenuItemAsync(newMenuItem);
        }

        public async Task DeleteMenuItemAsync(int id)
        {
            var menuItemFound = await _menuItemRepository.GetMenuItemByIdAsync(id);
            await _menuItemRepository.DeleteMenuItemAsync(menuItemFound);
        }

        public async Task UpdateMenuItemAsync(UpdateMenuItemDTO updateMenuItem)
        {
            var menuItem = await _menuItemRepository.GetMenuItemByIdAsync(updateMenuItem.ItemId);

            menuItem.Name = updateMenuItem.Name;
            menuItem.Price = updateMenuItem.Price;
            menuItem.IsAvailable = updateMenuItem.IsAvailable;

            await _menuItemRepository.UpdateMenuItemAsync(menuItem);
        }
    }
}
