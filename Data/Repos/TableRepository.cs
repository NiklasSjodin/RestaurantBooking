using Microsoft.EntityFrameworkCore;
using RestaurantBooking.Data.Repos.IRepos;
using RestaurantBooking.Models;

namespace RestaurantBooking.Data.Repos
{
    public class TableRepository : ITableRepository
    {
        private readonly RestaurantContext _context;
        public TableRepository(RestaurantContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Table>> GetAllTablesAsync()
        {
           return await _context.Tables.ToListAsync();
        }

        public Task<Table> GetTableByIdAsync(int id)
        {
            var table = _context.Tables.FirstOrDefaultAsync(t => t.TableID == id);
            return table;
        }

        public async Task AddTableAsync(Table table)
        {
            await _context.Tables.AddAsync(table);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTableAsync(Table table)
        {
            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTableAsync(Table table)
        {
            _context.Tables.Update(table);
            await _context.SaveChangesAsync();
        }
    }
}
