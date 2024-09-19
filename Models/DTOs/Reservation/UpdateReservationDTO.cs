namespace RestaurantBooking.Models.DTOs.Reservation
{
    public class UpdateReservationDTO
    {
        public int ReservationId { get; set; }
        public DateTime Time { get; set; }
        public int NumberOfGuests { get; set; }
    }
}
