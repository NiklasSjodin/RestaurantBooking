namespace RestaurantBooking.Models.DTOs.Reservation
{
    public class CreateReservationDTO
    {
        public int TableID { get; set; }
        public int CustomerID { get; set; }
        public DateTime Time { get; set; }
        public int NumberOfGuests { get; set; }

    }
}
