using System.ComponentModel.DataAnnotations;

namespace RestaurantBooking.Models
{
    public class Customer
    {
        [Key] 
        public int CustomerID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string PhoneNumber { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
