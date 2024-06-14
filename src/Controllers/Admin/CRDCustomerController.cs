using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.Data;
using src.Models;
using src.Services.Admin.ManageCustomer;
using src.Services.Admin.ManageUser;
using src.Until;

namespace src.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CRDCustomerController : ControllerBase
    {
        private ICreateCustomer _createCustomer;
        private IDeleteCustomer _deleteCustomer;
        public CRDCustomerController(ICreateCustomer createCustomer, IDeleteCustomer deleteCustomer)
        {
            _deleteCustomer = deleteCustomer;
            _createCustomer = createCustomer;   
        }
        //[HttpGet(Name = "GetAllUser")]
        //public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomerAsync()
        //{
        //}
        //[HttpGet("Id", Name = "GetUserById")]
        //public async Task<ActionResult<Customer>> GetUserByIdAsync(int id)
        //{

        //}
        [HttpPost("Create",Name = "CreateNewCustomer")]
        public async Task<IActionResult> CreateNewCustomerAsync([FromBody] RegristCustomer customer)
        {
            var pwd = await _createCustomer.CreateCustomerAsync(customer);
            return Ok(pwd);
        }
        [HttpDelete("id",Name = "DeleteCustomer")]
        public async Task DeleteCustomer(int id)
        {
            await _deleteCustomer.DeleteCustomerAsync(id);
        }

    }
}
