using Microsoft.AspNetCore.Mvc;
using src.Models;

namespace src.Clients.Admin.ManageCustomer
{
    public interface IGetCustomer
    {
        Task<dynamic> GetCustomerByIdAsync(int id);
        Task<IEnumerable<Customer>> GetAllCustomerAsync();
    }
}
