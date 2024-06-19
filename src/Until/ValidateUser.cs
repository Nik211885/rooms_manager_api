using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Models;
using BC = BCrypt.Net.BCrypt;

namespace src.Until
{
    public class ValidateUser
    {
        private readonly RoomsManagerDbConText _dbContext;
        public ValidateUser(RoomsManagerDbConText dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Verify user come request
        /// </summary>
        /// <param name="userRequest">User request in form login</param>
        /// <returns>
        /// string if throw message error
        /// or return object user if username and password is correct
        /// </returns>
        public async Task<dynamic> GetUserAsync(UserRequest userRequest)
        {
            var user = await _dbContext.Users.Where(u=>u.Phone == userRequest.Phone).FirstOrDefaultAsync();
            //0 email not correct
            if (user == null) 
                return "Phone is not correct";
            //1 password not correct
            var ValCustomer = new ValidateCustomer(_dbContext);
            var verifyPassword = VerifyPassword(user).Invoke(userRequest);
            if (!verifyPassword)
            {
                return "Password is not correct";
            }
            var verifyIsDelete = await ValCustomer.IsDeletedAsync(user.Id);
            if (verifyIsDelete)
            {
                return "Customer has deleted";
            }
            return user;
        }
        /// <summary>
        /// Verify your password
        /// </summary>
        /// <param name="user">User want to verify password</param>
        /// <returns>Return true if password is correct</returns>
        private Func<UserRequest, bool> VerifyPassword(User user)
        {
            return u => (
                BC.Verify(u.Password, user.PasswordHash)
            );
        }
        /// <summary>
        ///     Check customer form have customer phone is exits before
        /// </summary>
        /// <param name="customer">
        ///     Customer is form make regrist new customer
        /// </param>
        /// <returns>
        ///     Return false if phone customer is exits otherwise true
        /// </returns>
        public async Task<bool> IsPhoneUnique(RegristCustomer customer)
        {
            return !await _dbContext.Users.Where(u => u.Phone == customer.Phone).AnyAsync ();
        }
    }
}
