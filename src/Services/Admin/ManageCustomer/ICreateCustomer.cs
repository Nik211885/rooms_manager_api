using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.Models;

namespace src.Services.Admin.ManageUser
{
    public interface ICreateCustomer
    {
        Task<ActionResult<string>> CreateCustomerAsync(RegristCustomer customer);
    }
}
