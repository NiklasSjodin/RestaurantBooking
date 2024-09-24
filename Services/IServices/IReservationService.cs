using RestaurantBooking.Models;
using RestaurantBooking.Models.DTOs.Reservation;

namespace RestaurantBooking.Services.IServices
{
    public interface IReservationService
    {
        Task<IEnumerable<GetReservationDTO>> GetAllReservationsAsync();
        Task<GetReservationDTO> GetReservationByIdAsync(int id);
        Task AddReservationAsync(CreateReservationDTO createReservation);
        Task UpdateReservationAsync(UpdateReservationDTO updateReservation);
        Task DeleteReservationAsync(int id);
    }
}
