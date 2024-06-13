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
        public async Task<User?> GetUserAsync(UserRequest userRequest)
        {
            var user = await _dbContext.Users.Where(u=>IsUser().Invoke(userRequest))
                .Select(u=>u).FirstOrDefaultAsync();
            return user;
        }
        private Func<UserRequest, bool> IsUser()
        {
            return u => (
                u.Phone.Equals(_dbContext.Users.Select(u=>u.Phone).FirstOrDefault()) &&
                BC.Verify(u.Password, _dbContext.Users.Select(u=>u.PasswordHash).FirstOrDefault())
            );
        }
    }
}
