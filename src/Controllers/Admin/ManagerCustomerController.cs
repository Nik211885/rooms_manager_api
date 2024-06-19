using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Clients.Admin.ManageCustomer;
using src.Clients.Admin.ManageUser;

namespace src.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ManagerCustomerController : ControllerBase
    {
        private readonly ICreateCustomer _createCustomer;
        private readonly IGetCustomer _getCustomer;
        private readonly IUpdateCustomer _updateCustomer;
        public ManagerCustomerController(IGetCustomer getCustomer,ICreateCustomer createCustomer, IUpdateCustomer updateCustomer)
        {
            _updateCustomer = updateCustomer;
            _getCustomer = getCustomer;
            _createCustomer = createCustomer;   
        }
        [HttpPost("Create",Name = "CreateNewCustomer")]
        public async Task<ActionResult<dynamic>> CreateNewCustomerAsync([FromBody] RegristCustomer customer)
        {
            var result = await _createCustomer.CreateCustomerAsync(customer);
            if(result.GetType() == typeof(string))
            {
                return BadRequest(result);
            }
            //With result is user name and password customer in feat feature we add services send result to phone or email customer
            return Ok(result);
        }
        [HttpPut("SoftDelete/{id}",Name = "SoftDeleteCustomer")]
        public async Task<IActionResult> SoftDeleteCustomerAsync(int id)
        {
            var result = await _updateCustomer.SoftDeletedCustomerAsync(id);
            if(result.GetType() == typeof(string))
            {
                return BadRequest(result);
            }
            return NoContent();
        }
        [HttpGet("id",Name = "GetCustomerById")]
        public async Task<ActionResult<dynamic>> GetCustomerByIdAsync(int id)
        {
            var result = await _getCustomer.GetCustomerByIdAsync(id);
            if(result.GetType() == typeof(string))
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("GetAllCustomer",Name = "GetAll")]
        public async Task<ActionResult<Customer>> GetAllCustomerAsync()
        {
            var customers = await _getCustomer.GetAllCustomerAsync();
            return Ok(customers);
        }
        [HttpPut("OpenDeleted/{id}",Name = "OpenDeletedCustomer")]
        public async Task<IActionResult> OpenDeletedCustomerAsync(int id)
        {
            var result = await _updateCustomer.OpenCustomerAsync(id);
            if(result.GetType() == typeof(string))
            {
                return BadRequest(result);
            }
            return NoContent();
        }
    }
}
