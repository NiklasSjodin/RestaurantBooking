namespace RestaurantBooking.Models.DTOs.MenuItem
{
    public class GetMenuItemDTO
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsAvailable { get; set; }
    }
}
