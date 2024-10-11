using Microsoft.EntityFrameworkCore;
using RestaurantBooking.Data.Repos.IRepos;
using RestaurantBooking.Models;
using System.Linq;

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
           return await _context.Tables.AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<Table>> GetAvailableTablesAsync(DateTime reservationDate, int numberOfGuests)
        {
            var endTime = reservationDate.AddMinutes(120);

            var overlappingReservations = await _context.Reservations
                .Where(r => (r.Time < endTime) && (r.Time.AddMinutes(120) > reservationDate))
                .ToListAsync();

            var bookedTableIds = overlappingReservations.Select(r => r.FK_TableId).ToList();

            var availableTables = await _context.Tables
                 .Where(t => t.NumberOfSeats >= numberOfGuests && !bookedTableIds.Contains(t.TableID))
                 .ToListAsync();

            return availableTables;
        }
        public Task<Table> GetTableByIdAsync(int id)
        {
            var table = _context.Tables.AsNoTracking().FirstOrDefaultAsync(t => t.TableID == id);
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
