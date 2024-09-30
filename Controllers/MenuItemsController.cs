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
            try
            {
                var menuItems = await _menuItemService.GetAllMenuItemsAsync();
                return Ok(menuItems);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected eror occurred.");
            }

        }

        [HttpGet]
        [Route("menuItem/{id}")]
        public async Task<ActionResult<GetMenuItemDTO>> GetMenuItemById(int id)
        {
            try
            {
                var menuItem = await _menuItemService.GetMenuItemByIdAsync(id);
                return Ok(menuItem);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected eror occurred.");
            }
            
        }

        [HttpPost]
        [Route("createMenuItem")]
        public async Task<ActionResult> CreateMenuItem(CreateMenuItemDTO createMenuItem)
        {
            try
            {
                await _menuItemService.AddMenuItemAsync(createMenuItem);
                return Ok(createMenuItem);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the menu item.");
            }

        }

        [HttpPut]
        [Route("updateMenuItem/{id}")]
        public async Task<ActionResult> UpdateMenuItem(int id, UpdateMenuItemDTO updateMenuItem)
        {
            try
            {
                await _menuItemService.UpdateMenuItemAsync(updateMenuItem);
                return Ok(updateMenuItem);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the menu item.");
            }

        }

        [HttpDelete]
        [Route("deleteMenuItem/{id}")]
        public async Task<ActionResult> DeleteMenuItem(int id)
        {
            try
            {
                await _menuItemService.DeleteMenuItemAsync(id);
                return Ok("Menu Item deleted");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"No menu item with ID {id} found!");
            }

        }
    }
}
