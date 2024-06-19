using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Models;
using BC = BCrypt.Net;

namespace src.SeederData
{
    public static class SeederCustomer
    {
        public static async Task SeederAsync(RoomsManagerDbConText dbContext)
        {
            if(await dbContext.Customer.AnyAsync())
            {
                return;
            }
            var customer = new Customer()
            {
                Address = "Ha Noi",
                Deleted = false,
                FullName = "Nguyen Van An",
                IdNumber = "09999999999",
                User = new User()
                {
                    Phone = "0369888888",
                    Role = "User",
                    PasswordHash = BC.BCrypt.HashPassword("K@lnt21082003")
                },
            };
            dbContext.Customer.Add(customer);   
            await dbContext.SaveChangesAsync();
        }
    }
}
