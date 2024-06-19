using Microsoft.AspNetCore.Mvc;

namespace src.Clients.Admin.ManageCustomer
{
    public interface IUpdateCustomer
    {
        Task<dynamic> SoftDeletedCustomerAsync(int customerId);
        Task<dynamic> OpenCustomerAsync(int customerId);
    }
}
