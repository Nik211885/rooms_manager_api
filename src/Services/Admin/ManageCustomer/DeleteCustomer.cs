using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using src.Data;

namespace src.Services.Admin.ManageCustomer
{
    public class DeleteCustomer : ControllerBase, IDeleteCustomer
    {
        private readonly RoomsManagerDbConText _dbContext;
        public DeleteCustomer(RoomsManagerDbConText dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ActionResult> DeleteCustomerAsync(int id)
        {
            if(id <= 0)
            {
                return BadRequest("User not exits");
            }
            var u = await _dbContext.Customer.Where(c => c.Id == id && c.Deleted == false).FirstOrDefaultAsync();
            if (u == null)
            {
                return BadRequest("User not exits");
            }
            u.Deleted = true;
            return NoContent();
        }
    }
}
