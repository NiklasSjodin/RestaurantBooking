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
                Description = mi.Description,
                Price = mi.Price,
                TypeOf = mi.TypeOf,
                IsAvailable = mi.IsAvailable,
            }).ToList();
            return menuItemsList;
        }

        public async Task<GetMenuItemDTO> GetMenuItemByIdAsync(int id)
        {
            var foundMenuItem = await _menuItemRepository.GetMenuItemByIdAsync(id);

            if(foundMenuItem != null)
            {
                var menuItem = new GetMenuItemDTO
                {
                    ItemId = foundMenuItem.ItemId,
                    Name = foundMenuItem.Name,
                    Description = foundMenuItem.Description,
                    Price = foundMenuItem.Price,
                    TypeOf = foundMenuItem.TypeOf,
                    IsAvailable = foundMenuItem.IsAvailable,
                };
                return menuItem;
            }
            else
            {
                throw new KeyNotFoundException($"Menu Item with ID {id} not found!");
            }
            

        }
        public async Task AddMenuItemAsync(CreateMenuItemDTO createMenuItem)
        {
            var newMenuItem = new MenuItem
            {
                Name = createMenuItem.Name,
                Description = createMenuItem.Description,
                Price = createMenuItem.Price,
                TypeOf = createMenuItem.TypeOf,
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

            if(menuItem != null)
            {
                menuItem.Name = updateMenuItem.Name;
                menuItem.Description = updateMenuItem.Description;
                menuItem.Price = updateMenuItem.Price;
                menuItem.IsAvailable = updateMenuItem.IsAvailable;

                await _menuItemRepository.UpdateMenuItemAsync(menuItem);
            }
            else
            {
                throw new KeyNotFoundException("Menu Item not found!");
            }
        }
    }
}
