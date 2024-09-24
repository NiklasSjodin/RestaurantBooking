namespace RestaurantBooking.Models.DTOs.Reservation
{
    public class GetReservationDTO
    {
        public int ReservationId { get; set; }
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public DateTime Time { get; set; }
        public int TableNumber { get; set; }
        public int NumberOfGuests { get; set; }
    }
}
