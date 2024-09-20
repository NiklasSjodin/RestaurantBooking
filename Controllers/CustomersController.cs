using Microsoft.AspNetCore.Mvc;
using RestaurantBooking.Models.DTOs.Customer;
using RestaurantBooking.Services.IServices;

namespace RestaurantBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpGet]
        [Route("customer/{id}")]
        public async Task<ActionResult<GetCustomerDTO>> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            return Ok(customer);
        }

        [HttpPost]
        [Route("createCustomer")]
        public async Task<ActionResult> CreateCustomer(CreateCustomerDTO createCustomer)
        {
            await _customerService.AddCustomerAsync(createCustomer);

            return Ok("Customer created successfully!");
        }

        [HttpPut]
        [Route("updateCustomer/{id}")]
        public async Task<ActionResult> UpdateCustomer(int id, UpdateCustomerDTO updateCustomer)
        {
            await _customerService.UpdateCustomerAsync(updateCustomer);
            return Ok("Customer updated!");
        }

        [HttpDelete]
        [Route("deleteCustomer/{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            await _customerService.DeleteCustomerAsync(id);
            return Ok("Customer deleted!");
        }
    }
}
