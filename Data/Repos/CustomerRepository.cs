using Microsoft.EntityFrameworkCore;
using RestaurantBooking.Data.Repos.IRepos;
using RestaurantBooking.Models;

namespace RestaurantBooking.Data.Repos
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly RestaurantContext _context;
        public CustomerRepository(RestaurantContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.AsNoTracking().ToListAsync();
        }
        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            var customer = await _context.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.CustomerID == id);

            return customer;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(Customer customer)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}
