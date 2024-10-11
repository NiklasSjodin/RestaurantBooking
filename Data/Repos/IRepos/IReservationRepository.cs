using Microsoft.AspNetCore.Mvc;
using RestaurantBooking.Models;

namespace RestaurantBooking.Data.Repos.IRepos
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetAllReservationsAsync();
        Task<Reservation> GetReservationByIdAsync(int id);
        Task<IEnumerable<Reservation>> GetReservationsBetweenAsync(DateTime starTime, DateTime endTime);
        Task AddReservationAsync(Reservation reservation);
        Task UpdateReservationAsync(Reservation reservation);
        Task DeleteReservationAsync(Reservation reservation);
    }
}
