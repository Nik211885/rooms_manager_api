using Microsoft.AspNetCore.Mvc;
using src.Data;
using src.Models;
using src.Services.ServicesShared.LogIO;

namespace src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogIOController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly RoomsManagerDbConText _dbContext;
        private readonly ILogIO _logIo;

        public LogIOController(IConfiguration configuration, RoomsManagerDbConText dbContext, ILogIO logIo)
        {
            _configuration = configuration;
            _dbContext = dbContext;
            _logIo = logIo;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserRequest user)
        {
            if(user == null)
            {
                return BadRequest("User don't empty");
            }
            if (!await _logIo.ServiceLoginAsync(user, _dbContext, _configuration, HttpContext))
            {
                return BadRequest("User name or password not correct");
            }
            return Ok("Login Success");
        }
        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            _logIo.ServiceLogout(HttpContext);
            return Ok("Logout Success");
        }
    }
}
