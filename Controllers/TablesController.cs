using Microsoft.AspNetCore.Mvc;
using RestaurantBooking.Models.DTOs.Table;
using RestaurantBooking.Services.IServices;

namespace RestaurantBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly ITableService _tableService;
        public TablesController(ITableService tableService)
        {
             _tableService = tableService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTables()
        {
            try
            {
                var tables = await _tableService.GetAllTablesAsync();
                return Ok(tables);
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
        [Route("table/{id}")]
        public async Task<ActionResult<GetTableDTO>> GetTablesById(int id)
        {
            try
            {
                var table = await _tableService.GetTableByIdAsync(id);
                return Ok(table);
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
        [Route("createTable")]
        public async Task<ActionResult> CreateTable(CreateTableDTO createTable)
        {
            try
            {
                await _tableService.AddTableAsync(createTable);
                return Ok(createTable);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the table.");
            }

        }

        [HttpPut]
        [Route("updateTable/{id}")]
        public async Task<ActionResult> UpdateTable(int id, UpdateTableDTO updateTable)
        {
            try
            {
                await _tableService.UpdateTableAsync(updateTable);
                return Ok(updateTable);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the table.");
            }
        }

        [HttpDelete]
        [Route("deleteTable/{id}")]
        public async Task<ActionResult> DeleteTable(int id)
        {
            try
            {
                await _tableService.DeleteTableAsync(id);
                return Ok("Table deleted!");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"No table with ID {id} found!");
            }

        }
    }
}
