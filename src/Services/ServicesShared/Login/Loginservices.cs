﻿using Microsoft.IdentityModel.Tokens;
using src.Data;
using src.Models;
using src.Until;
using System.Dynamic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace src.Services.ServicesShared.Login
{
    public class LoginServices : ILogin
    {
        private readonly RoomsManagerDbConText _dbContext;
        private readonly IConfiguration _configuration;
        public LoginServices(RoomsManagerDbConText dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration; 

        }
        public async Task<dynamic> ServiceLoginAsync(UserRequest user)
        {
            if (user == null)
            {
                return "User don't empty";
            }
            var val = new ValidateUser(_dbContext);
            var result = await val.GetUserAsync(user);
            var type = result.GetType();
            if (type == typeof(string))
            {
                return result;
            }
            dynamic jwt = new ExpandoObject();
            jwt.JwtToken = GetJwtToke(result, _configuration);
            return jwt;
        }
        private static string GetJwtToke(User user, IConfiguration config)
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
                    signingCredentials: new SigningCredentials(key,SecurityAlgorithms.HmacSha512),
                    audience: config["Jwt:Audience"],
                    issuer: config["Jwt:Issuer"]
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
