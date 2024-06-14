using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace src.Services.Admin.ManageCustomer
{
    public interface IDeleteCustomer
    {
        Task<ActionResult> DeleteCustomerAsync(int id);
    }
}
