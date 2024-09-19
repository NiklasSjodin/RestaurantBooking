using RestaurantBooking.Models;
using RestaurantBooking.Models.DTOs.Customer;

namespace RestaurantBooking.Services.IServices

{
    public interface ICustomerService
    {
        Task<IEnumerable<GetCustomerDTO>> GetAllCustomersAsync();
        Task<GetCustomerDTO> GetCustomerByIdAsync(int id);
        Task AddCustomerAsync(CreateCustomerDTO createCustomer);
        Task UpdateCustomerAsync(UpdateCustomerDTO updateCustomer);
        Task DeleteCustomerAsync(int id);
    }
}
