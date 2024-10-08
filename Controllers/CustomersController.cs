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
            try
            {
                var customers = await _customerService.GetAllCustomersAsync();
                return Ok(customers);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected eror occurred.");
            }

        }

        [HttpGet]
        [Route("customer/{id}")]
        public async Task<ActionResult<GetCustomerDTO>> GetCustomerById(int id)
        {
            try
            {
                var customer = await _customerService.GetCustomerByIdAsync(id);
                return Ok(customer);
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected eror occurred.");
            }
        }

        [HttpPost]
        [Route("createCustomer")]
        public async Task<ActionResult> CreateCustomer(CreateCustomerDTO createCustomer)
        {
            try
            {
                var newCustomer = await _customerService.AddCustomerAsync(createCustomer);

                return Ok(newCustomer);
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the customer.");
            }
            
        }

        [HttpPut]
        [Route("updateCustomer/{id}")]
        public async Task<ActionResult> UpdateCustomer(int id, UpdateCustomerDTO updateCustomer)
        {
            try
            {
                await _customerService.UpdateCustomerAsync(updateCustomer);
                return Ok(updateCustomer);
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }catch(Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the customer.");
            }
            
        }

        [HttpDelete]
        [Route("deleteCustomer/{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            try
            {
                await _customerService.DeleteCustomerAsync(id);
                return Ok("Customer deleted!");
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"No customer with ID {id} found!");
            }
        }
    }
}
