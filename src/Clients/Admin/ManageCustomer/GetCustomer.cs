using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Models;

namespace src.Clients.Admin.ManageCustomer
{
    public class GetCustomer : IGetCustomer
    {
        private readonly RoomsManagerDbConText _dbContext;
        public GetCustomer(RoomsManagerDbConText dbContext)
        {
            _dbContext = dbContext;
        }
        //Get all user has deleted and user not deleted
        public async Task<IEnumerable<Customer>> GetAllCustomerAsync()
        {
            var customers = await _dbContext.Customer.ToListAsync();
            return customers;
        }
        public async Task<dynamic> GetCustomerByIdAsync(int id)
        {
            if(id <= 0)
            {
                return ("id invalid");
            }
            var u = await _dbContext.Customer.Where(c=>c.Id == id).FirstOrDefaultAsync();
            if(u == null)
            {
                return ("User not exits");
            }
            return u;
        }
    }
}
