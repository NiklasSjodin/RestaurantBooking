﻿namespace RestaurantBooking.Models.DTOs.MenuItem
{
    public class GetMenuItemDTO
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string TypeOf { get; set; }
        public bool IsAvailable { get; set; }
    }
}
