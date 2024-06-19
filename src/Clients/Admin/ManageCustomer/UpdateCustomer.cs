using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Until;

namespace src.Clients.Admin.ManageCustomer
{
    public class UpdateCustomer : IUpdateCustomer
    {
        private readonly RoomsManagerDbConText _dbContext;
        public UpdateCustomer(RoomsManagerDbConText dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<dynamic> OpenCustomerAsync(int customerId)
        {
            // check if customer has exits
            // if customer has deleted => open deleted
            // if customer Not Deleted Yet 
            if(customerId <= 0)
            {
                return ("Id is not correct");
            }
            var valC = new ValidateCustomer(_dbContext);
            if (await valC.IsDeletedCustomerAsync(customerId))
            {
                var c = await _dbContext.Customer.FirstOrDefaultAsync(c => c.Id == customerId);
                if(c == null)
                {
                    return ("Customer has deleted");
                }
                else
                {
                    c.Deleted = false;
                    _dbContext.Update(c);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
            }
            else
            {
                return ("Customer Not Deleted Yet");
            }
        }
        public async Task<dynamic> SoftDeletedCustomerAsync(int customerId)
        {
            if(customerId <= 0)
            {
                return ("Id is not correct");
            }
            var customer = await _dbContext.Customer.Where(c=>c.Id == customerId).FirstOrDefaultAsync();
            if(customer == null)
            {
                return ("Customer is not exits");
            }
            //0> if customer is deleted cant deleted this customer
            //1> in contract if customer out of date deleted customer is ok 
            //2> else if contract still of date so should deleted customer !!
            var valC = new ValidateCustomer(_dbContext);
            //0 check if customer has deleted
            if(await valC.IsDeletedCustomerAsync(customerId))
            {
                return ("Customer has deleted!");
            }
            //1 if contract out of date
            var ValContract = new ValidateContract(_dbContext);
            if (await ValContract.IsContractOutOfDate(customerId))
            {
                //Admin Self Delete User has contract out of date
                //Soft Deleted
                //Problem if contract out of date and admin still delete customer so customer is still exits
                customer.Deleted = true;
                _dbContext.Update(customer);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                //2 if contract still of date cant delete customer
                return ("Contract still of date");
            }
            
        }
    }
}
