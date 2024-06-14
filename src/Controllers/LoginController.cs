using Microsoft.AspNetCore.Mvc;
using src.Data;
using src.Models;
using src.Services.ServicesShared.Login;
using src.Until;
using System.Runtime.Remoting;

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
            var jwt = await _login.ServiceLoginAsync(user);
            return Ok(jwt);
        }
    }
}
