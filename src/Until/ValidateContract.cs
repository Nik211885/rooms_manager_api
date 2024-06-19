using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Models;

namespace src.Until
{
    public class ValidateContract
    {
        private readonly RoomsManagerDbConText _dbContext;
        public ValidateContract(RoomsManagerDbConText dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Find contract customer's have out of date
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>
        ///     Return true if contract out of date or customer don't have contract false otherwise
        /// </returns>
        public async Task<bool> IsContractOutOfDate(int customerId)
        {
            var result = await _dbContext.Contracts.
                Where(c => c.Customer.Id.Equals(customerId)).
                FirstOrDefaultAsync();
            if(result == null)
            {
                return true;
            }
            if(result.ExpirationDate <= DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
}
