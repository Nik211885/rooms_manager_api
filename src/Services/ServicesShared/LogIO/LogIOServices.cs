using Microsoft.IdentityModel.Tokens;
using src.Data;
using src.Models;
using src.Until;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace src.Services.ServicesShared.LogIO
{
    public class LogIOServices : ILogIO
    {
        private readonly string _keyCookie = "jwt-bearer";
        public async Task<bool> ServiceLoginAsync(UserRequest userRequest, RoomsManagerDbConText dbContext, IConfiguration config, HttpContext context)
        {
            var ValUser = new ValidateUser(dbContext);
            var user = await ValUser.GetUserAsync(userRequest);
            if(user == null)
            {
                return false;
            }
            SaveJwtInsideCookie(user, config, context);
            return true;
        }

        public void ServiceLogout(HttpContext context)
        {
            context.Response.Cookies.Delete(_keyCookie);
        }

        private void SaveJwtInsideCookie(User user, IConfiguration config, HttpContext context)
        {
            var claims = new List<Claim>()
            {
                new (ClaimTypes.NameIdentifier, user.Id.ToString()),
                new (ClaimTypes.Role, user.Role)
            };
            //key hash bytes
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: new SigningCredentials(key,SecurityAlgorithms.HmacSha512)
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            context.Response.Cookies.Append(_keyCookie, jwt, new CookieOptions()
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddDays(1),
                Secure = true,
                SameSite = SameSiteMode.None,
            });
        }
    }
}
