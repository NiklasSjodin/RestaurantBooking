using System.ComponentModel.DataAnnotations;

namespace RestaurantBooking.Models
{
    public class MenuItem
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }
        [Required]
        public string TypeOf { get; set; }

        [Required]
        public bool IsAvailable { get; set; } 
    }
}
