using Microsoft.EntityFrameworkCore;
using src.Data;

namespace src.Until
{
    public class ValidateCustomer
    {
        private readonly RoomsManagerDbConText _dbContext;
        public ValidateCustomer(RoomsManagerDbConText dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> IsDeleted(int userId)
        {
            var result = await _dbContext.Customer.Where(c => c.Deleted == true && c.User.Id == userId).Select(c=>c).FirstOrDefaultAsync();
            return result == null;
        } 
    }
}
