using PasswordGenerator;
using src.Data;
using src.Models;
using src.Until;
using System.Dynamic;
using BC = BCrypt.Net;

namespace src.Clients.Admin.ManageUser
{
    public class CreateCustomer : ICreateCustomer
    {
        private readonly RoomsManagerDbConText _dbContext;
        public CreateCustomer(RoomsManagerDbConText dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<dynamic> CreateCustomerAsync(RegristCustomer customer)
        {
            if (customer == null)
            {
                return "Customer not null";
            }
            //1> If phone number is exits return 
            //2> If idNumber is exits return if you want change status deleted search customer by idNumber and change status deleted
            var valC = new ValidateCustomer(_dbContext);
            var valU = new ValidateUser(_dbContext);
            if (!await valU.IsPhoneUnique(customer))
            {
                return "This phone has regrist before";
            }
            if (!await valC.IsIdNumberUnique(customer))
            {
                return "This person has regrist before";
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
            //Feature in future extensible if admin regrist new customer can send send random password 
            //for email or phone
            dynamic account = new ExpandoObject();
            account.UserName = customer.Phone;
            account.Password = randomPassword;
            return account;
        }
    }
}
