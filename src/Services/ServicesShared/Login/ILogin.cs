using Microsoft.AspNetCore.Mvc;
using src.Data;
using src.Models;

namespace src.Services.ServicesShared.Login
{
    public interface ILogin
    {
        Task<ActionResult<string>> ServiceLoginAsync(UserRequest user);
    }
}
