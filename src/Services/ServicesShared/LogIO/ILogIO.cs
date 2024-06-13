using Microsoft.AspNetCore.Mvc;
using src.Data;
using src.Models;

namespace src.Services.ServicesShared.LogIO
{
    public interface ILogIO
    {
        Task<bool> ServiceLoginAsync(UserRequest user, RoomsManagerDbConText dbContext, IConfiguration config, HttpContext context);
        void ServiceLogout(HttpContext context);
    }
}
