using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantBooking.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public int NumberOfGuests { get; set; }


        [ForeignKey("Customer")]
        public int FK_CustomerID { get; set; }
        public Customer Customer { get; set; }


        [ForeignKey("Table")]
        public int FK_TableId { get; set; }
        public Table Table { get; set; }
    }
}
