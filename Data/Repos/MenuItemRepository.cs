using Microsoft.EntityFrameworkCore;
using RestaurantBooking.Data.Repos.IRepos;
using RestaurantBooking.Models;

namespace RestaurantBooking.Data.Repos
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly RestaurantContext _context;
        public MenuItemRepository(RestaurantContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync()
        {
            return await _context.MenuItems.AsNoTracking().ToListAsync();
        }

        public async Task<MenuItem> GetMenuItemByIdAsync(int id)
        {
            var menuItem = await _context.MenuItems.AsNoTracking().FirstOrDefaultAsync(mi => mi.ItemId == id);
            return menuItem;
        }
        public async Task AddMenuItemAsync(MenuItem item)
        {
            await _context.MenuItems.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMenuItemAsync(MenuItem item)
        {
            _context.MenuItems.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMenuItemAsync(MenuItem item)
        {
            _context.MenuItems.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
