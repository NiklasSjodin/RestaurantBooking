using RestaurantBooking.Data.Repos.IRepos;
using RestaurantBooking.Models;
using RestaurantBooking.Models.DTOs.Customer;
using RestaurantBooking.Services.IServices;

namespace RestaurantBooking.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository userRepo)
        {
            _customerRepository = userRepo;
        }
        public async Task<IEnumerable<GetCustomerDTO>> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAllCustomersAsync();

            var customerList = customers.Select(c => new GetCustomerDTO
            {
                CustomerID = c.CustomerID,
                FirstName = c.FirstName,
                LastName = c.LastName,
                PhoneNumber = c.PhoneNumber,
            });

            return customerList;
        }
        public async Task<GetCustomerDTO> GetCustomerByIdAsync(int id)
        {
            var foundCustomer = await _customerRepository.GetCustomerByIdAsync(id);

            var customer = new GetCustomerDTO
            {
                CustomerID = foundCustomer.CustomerID,
                FirstName = foundCustomer.FirstName,
                LastName = foundCustomer.LastName,
                PhoneNumber = foundCustomer.PhoneNumber,
            };

            return customer;
        }
        public async Task AddCustomerAsync(CreateCustomerDTO createCustomer)
        {
            var newCustomer = new Customer
            {
                FirstName = createCustomer.FirstName,
                LastName = createCustomer.LastName,
                PhoneNumber = createCustomer.PhoneNumber,
            };

            await _customerRepository.AddCustomerAsync(newCustomer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customerFound = await _customerRepository.GetCustomerByIdAsync(id);
            await _customerRepository.DeleteCustomerAsync(customerFound);
        }

        public async Task UpdateCustomerAsync(UpdateCustomerDTO updateCustomer)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(updateCustomer.CustomerID);

            customer.FirstName = updateCustomer.FirstName;
            customer.LastName = updateCustomer.LastName;
            customer.PhoneNumber = updateCustomer.PhoneNumber;

            await _customerRepository.UpdateCustomerAsync(customer);
        }
    }
}
