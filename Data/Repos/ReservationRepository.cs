using Microsoft.EntityFrameworkCore;
using RestaurantBooking.Data.Repos.IRepos;
using RestaurantBooking.Models;

namespace RestaurantBooking.Data.Repos
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly RestaurantContext _context;
        public ReservationRepository(RestaurantContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
        {
            return await _context.Reservations.AsNoTracking()
                .Include(r => r.Customer)
                .Include(r => r.Table)
                .ToListAsync();
        }

        public async Task<Reservation> GetReservationByIdAsync(int id)
        {
            var reservation = await _context.Reservations.AsNoTracking()
                .Include(r => r.Customer)
                .Include(r => r.Table)
                .FirstOrDefaultAsync(r => r.ReservationId == id);

            return reservation;
        }
        public async Task<IEnumerable<Reservation>> GetReservationsBetweenAsync(DateTime starTime, DateTime endTime)
        {
           return await _context.Reservations
                .Where(r => r.Time < endTime && r.Time.AddMinutes(120) > starTime)
                .ToListAsync();
        }

        public async Task AddReservationAsync(Reservation reservation)
        {
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReservationAsync(Reservation reservation)
        {
            _context.Reservations.Remove(reservation);
           await _context.SaveChangesAsync();
        }

        public async Task UpdateReservationAsync(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
        }

        
    }
}
