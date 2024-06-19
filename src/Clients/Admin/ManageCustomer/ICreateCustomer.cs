using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.Models;

namespace src.Clients.Admin.ManageUser
{
    public interface ICreateCustomer
    {
        Task<dynamic> CreateCustomerAsync(RegristCustomer customer);
    }
}
