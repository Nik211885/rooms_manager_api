using Microsoft.AspNetCore.Mvc;
using PasswordGenerator;
using src.Data;
using src.Models;
using src.Until;
using BC = BCrypt.Net;

namespace src.Services.Admin.ManageUser
{
    public class CreateCustomer : ControllerBase, ICreateCustomer
    {
        private readonly RoomsManagerDbConText _dbContext;
        public CreateCustomer(RoomsManagerDbConText dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ActionResult<string>> CreateCustomerAsync(RegristCustomer customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer not null");
            }
            var val = new ValidateUser(_dbContext);
            if (!await val.IsPhoneUnique(customer))
            {
                return BadRequest("Phone number must is unique");
            }
            if (!await val.IsIdNumberUnique(customer))
            {
                return BadRequest("Id number must unique");
            }
            var pwd = new Password(
                includeLowercase: true, 
                includeUppercase: true, 
                includeNumeric: true, 
                includeSpecial: true, 
                passwordLength: 12
                );
            var randomPassword = pwd.Next();
            var user = new User()
            {
                Phone = customer.Phone,
                Role = "User",
                PasswordHash = BC.BCrypt.HashPassword(randomPassword)
            };
            var NewCustomer = new Customer()
            {
                Address = customer.Address,
                Deleted = false,
                User = user,
                FullName = customer.FullName,
                IdNumber = customer.IdNumber
            };
            await _dbContext.Customer.AddAsync(NewCustomer);
            await _dbContext.SaveChangesAsync();
            return randomPassword;
        }
    }
}
