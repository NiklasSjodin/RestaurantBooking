using RestaurantBooking.Data.Repos.IRepos;
using RestaurantBooking.Models;
using RestaurantBooking.Models.DTOs.Reservation;

namespace RestaurantBooking.Services.IServices
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        public ReservationService(IReservationRepository reservationRepo)
        {
            _reservationRepository = reservationRepo;
        }

        public async Task<IEnumerable<GetReservationDTO>> GetAllReservationsAsync()
        {
            var reservations = await _reservationRepository.GetAllReservationsAsync();
            var reservationsList = reservations.Select(r => new GetReservationDTO
            {
                ReservationId = r.ReservationId,
                CustomerID = r.FK_CustomerID,
                FirstName = r.Customer.FirstName,
                Time = r.Time,
                TableNumber = r.Table.TableNumber,
            }).ToList();

            return reservationsList;
        }

        public async Task<GetReservationDTO> GetReservationByIdAsync(int id)
        {
            var reservation = await _reservationRepository.GetReservationByIdAsync(id);
            var reservationDTO = new GetReservationDTO
            {
                ReservationId = reservation.ReservationId,
                CustomerID = reservation.FK_CustomerID,
                FirstName = reservation.Customer.FirstName,
                Time = reservation.Time,
                TableNumber = reservation.Table.TableNumber,
            };

            return reservationDTO;
        }
        public async Task AddReservationAsync(CreateReservationDTO createReservation)
        {
            var newReservation = new Reservation
            {
                Time = createReservation.Time,
                NumberOfGuests = createReservation.NumberOfGuests,
                FK_TableId = createReservation.TableID,
                FK_CustomerID = createReservation.CustomerID,
            };

            await _reservationRepository.AddReservationAsync(newReservation);
        }

        public async Task DeleteReservationAsync(int id)
        {
            var reservationFound = await _reservationRepository.GetReservationByIdAsync(id);
            if (reservationFound != null)
            {
                await _reservationRepository.DeleteReservationAsync(reservationFound);
            }
        }

        public async Task UpdateReservationAsync(UpdateReservationDTO updateReservation)
        {
            var reservationFound = await _reservationRepository.GetReservationByIdAsync(updateReservation.ReservationId);
            if (reservationFound != null)
            {
                reservationFound.ReservationId = updateReservation.ReservationId;
                reservationFound.Time = updateReservation.Time;
                reservationFound.NumberOfGuests = updateReservation.NumberOfGuests;

                await _reservationRepository.UpdateReservationAsync(reservationFound);
            }
        }
    }
}
