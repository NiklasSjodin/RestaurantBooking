using System.ComponentModel.DataAnnotations;

namespace RestaurantBooking.Models
{
    public class Table
    {
        [Key]
        public int TableID { get; set; }

        [Required]
        public int TableNumber { get; set; }

        [Required]
        public int NumberOfSeats { get; set; }

        public ICollection<Reservation> Reservations { get; set; }  
    }
}
