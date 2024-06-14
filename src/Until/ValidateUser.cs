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
        /// Valid userRequest have correct
        /// </summary>
        /// <param name="userRequest">Data Form Login</param>
        /// <returns>
        /// If phone not correct return 0
        /// Else If password not correct return 1
        /// Else return user
        /// </returns>
        public async Task<dynamic> GetUserAsync(UserRequest userRequest)
        {
            var user = await _dbContext.Users.Where(u=>u.Phone == userRequest.Phone).FirstOrDefaultAsync();
            //0 email not correct
            if (user == null) return "Email is not correct";
            //1 password not correct
            var ValCustomer = new ValidateCustomer(_dbContext);
            if (!VerifyPassword(user).Invoke(userRequest) || !await ValCustomer.IsDeleted(user.Id)) return "Password is not correct";
            return user;
        }
        private Func<UserRequest, bool> VerifyPassword(User user)
        {
            return u => (
                BC.Verify(u.Password, user.PasswordHash)
            );
        }
        public async Task<bool> IsPhoneUnique(RegristCustomer customer)
        {
            var a = await _dbContext.Users.Where(u => u.Phone == customer.Phone).FirstOrDefaultAsync();
            if (a != null) return false;
            return true;
        }
        public async Task<bool> IsIdNumberUnique(RegristCustomer customer)
        {
            var u = await _dbContext.Customer.Where(c => c.IdNumber == customer.IdNumber).FirstOrDefaultAsync();
            if (u != null) return false;
            return true;
        }
    }
}
