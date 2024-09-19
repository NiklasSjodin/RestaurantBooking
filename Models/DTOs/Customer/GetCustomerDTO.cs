namespace RestaurantBooking.Models.DTOs.Customer
{
    public class GetCustomerDTO
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
