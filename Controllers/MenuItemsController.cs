using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantBooking.Models.DTOs.MenuItem;
using RestaurantBooking.Services.IServices;

namespace RestaurantBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;
        public MenuItemsController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMenuItems()
        {
            var menuItems = await _menuItemService.GetAllMenuItemsAsync();
            return Ok(menuItems);
        }

        [HttpGet]
        [Route("menuItem/{id}")]
        public async Task<ActionResult> GetMenuItemById(int id)
        {
            var menuItem = await _menuItemService.GetMenuItemByIdAsync(id);
            return Ok(menuItem);
        }

        [HttpPost]
        [Route("createMenItem")]
        public async Task<ActionResult> CreateMenuItem(CreateMenuItemDTO createMenuItem)
        {
            await _menuItemService.AddMenuItemAsync(createMenuItem);
            return Ok("Menu Item created successfully!");
        }

        [HttpPut]
        [Route("updateMenuItem/{id}")]
        public async Task<ActionResult> UpdateMenuItem(int id, UpdateMenuItemDTO updateMenuItem)
        {
            await _menuItemService.UpdateMenuItemAsync(updateMenuItem);
            return Ok("Menu Item updated!");
        }
        [HttpDelete]
        [Route("deleteMenuItem/{id}")]
        public async Task<ActionResult> DeleteMenuItem(int id)
        {
            await _menuItemService.DeleteMenuItemAsync(id);
            return Ok("Menu Item deleted");
        }
    }
}
