using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Models;

namespace src.Until
{
    public class ValidateCustomer
    {
        private readonly RoomsManagerDbConText _dbContext;
        public ValidateCustomer(RoomsManagerDbConText dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId">
        /// userId in table user
        /// </param>
        /// <returns>
        /// Return true if user is deleted
        /// </returns>
        public async Task<bool> IsDeletedAsync(int userId)
        {
            var result = await _dbContext.Customer.
                Where(c=>c.User.Id == userId && c.Deleted).
                Select(c=>c).AnyAsync();
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId">
        /// In table Customer
        /// </param>
        /// <returns>
        ///     Return true if customer is deleted
        /// </returns>
        public async Task<bool> IsDeletedCustomerAsync(int customerId)
        {
            var result = await _dbContext.Customer
                .Where(c => c.Id == customerId && c.Deleted)
                .AnyAsync();
            return result;
        }
        /// <summary>
        ///     Check customer idNumber have exits before
        /// </summary>
        /// <param name="customer">Customer in form regrist customer</param>
        /// <returns>
        ///     Return false if customerId is exits otherwise true
        /// </returns>
        public async Task<bool> IsIdNumberUnique(RegristCustomer customer)
        {
            var result =  !await _dbContext.Customer.Where(c => c.IdNumber == customer.IdNumber).AnyAsync();
            return result;
        }
    }
}
