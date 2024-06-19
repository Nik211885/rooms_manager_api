using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Services.ServicesShared.Login;

namespace src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _login;
        public LoginController(ILogin login)
        {
            _login = login;
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] UserRequest user)
        {
            var result = await _login.ServiceLoginAsync(user);
            if(result.GetType() == typeof(string))
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
