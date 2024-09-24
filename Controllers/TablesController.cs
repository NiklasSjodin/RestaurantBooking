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
            var tables = await _tableService.GetAllTablesAsync();
            return Ok(tables);
        }

        [HttpGet]
        [Route("table/{id}")]
        public async Task<ActionResult<GetTableDTO>> GetTablesById(int id)
        {
            var table = await _tableService.GetTableByIdAsync(id);
            return Ok(table);
        }

        [HttpPost]
        [Route("createTable")]
        public async Task<ActionResult> CreateTable(CreateTableDTO createTable)
        {
            await _tableService.AddTableAsync(createTable);
            return Ok(createTable);
        }

        [HttpPut]
        [Route("updateTable/{id}")]
        public async Task<ActionResult> UpdateTable(int id, UpdateTableDTO updateTable)
        {
            await _tableService.UpdateTableAsync(updateTable);
            return Ok(updateTable);
        }

        [HttpDelete]
        [Route("deleteTable/{id}")]
        public async Task<ActionResult> DeleteTable(int id)
        {
            await _tableService.DeleteTableAsync(id);
            return Ok("Table deleted!");
        }
    }
}
