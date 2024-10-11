using RestaurantBooking.Data.Repos.IRepos;
using RestaurantBooking.Models;
using RestaurantBooking.Models.DTOs.Reservation;
using RestaurantBooking.Services.IServices;
using System.Linq.Expressions;

namespace RestaurantBooking.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ITableRepository _tableRepository;
        public ReservationService(IReservationRepository reservationRepo, ITableRepository tableRepository)
        {
            _reservationRepository = reservationRepo;
            _tableRepository = tableRepository;
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
                NumberOfGuests = r.NumberOfGuests,
            }).ToList();

            return reservationsList;
        }

        public async Task<GetReservationDTO> GetReservationByIdAsync(int id)
        {
            var reservation = await _reservationRepository.GetReservationByIdAsync(id);

            if(reservation != null)
            {
                var reservationDTO = new GetReservationDTO
                {
                    ReservationId = reservation.ReservationId,
                    CustomerID = reservation.FK_CustomerID,
                    FirstName = reservation.Customer.FirstName,
                    Time = reservation.Time,
                    TableNumber = reservation.Table.TableNumber,
                    NumberOfGuests= reservation.NumberOfGuests,
                };

                return reservationDTO;
            }
            else
            {
                throw new KeyNotFoundException($"Reservation with ID {id} not found!");
            }

        }
        public async Task AddReservationAsync(CreateReservationDTO createReservation)
        {
            var table = await _tableRepository.GetTableByIdAsync(createReservation.TableID);

            if(table == null)
            {
                throw new KeyNotFoundException($"Table with Id {createReservation.TableID} not found.");
            }

            if (createReservation.NumberOfGuests > table.NumberOfSeats)
            {
                throw new InvalidOperationException($"Max guests for the table is {table.NumberOfSeats}.");
            }

            // Kontrollera att tiden är inom bokningsbara tiderna (17:00 till 23:00)
            var restaurantOpenTime = new TimeSpan(17, 0, 0);
            var restaurantCloseTime = new TimeSpan(23, 0, 0);

            // Check if the reservation time is outside the allowed hours
            if (createReservation.Time.TimeOfDay < restaurantOpenTime || createReservation.Time.TimeOfDay > restaurantCloseTime)
            {
                throw new ArgumentException("The restaurant is open between 17:00 and 23:00.");
            }

            var reservationEndTime = createReservation.Time.AddMinutes(120);

            var existingReservations = await _reservationRepository.GetReservationsBetweenAsync(createReservation.Time, reservationEndTime);
            if(existingReservations.Any(r => r.FK_TableId == createReservation.TableID))
            {
                throw new InvalidOperationException("The selected table is already booked for this time.");
            }

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
            else
            {
                throw new KeyNotFoundException("Reservation not found!");
            }
        }
    }
}
