using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Models;
using BC = BCrypt.Net;

namespace src.SeederData
{
    public static class SeederAdmin
    {
        public static async Task SeederAsync(RoomsManagerDbConText dbContext)
        {
            if(await dbContext.Admin.Select(a=>a).CountAsync() > 0)
            {
                return;
            }
            //Seeder one admin
            var admin = new Admin()
            {
                Address = "Việt Nam",
                BirthDay = new DateTime(2003, 05, 18),
                Email = "khacninh2020@gmail.com",
                FullName = "Lê Khắc Ninh",
                Gender = true,
                IdNumber = "11111111111",
                Image = @"/somewhere/thisfile.png",
                Information = "Hello I'm a software engineer",
                User =  new User()
                {
                    Phone = "0333333333",
                    Role = "Admin",
                    PasswordHash = BC.BCrypt.HashPassword("K@lnt211885")
                },
                Rooms =
                [
                    new ()
                    {Description = "NORMAL", Hired = false, ImageRoom = "../", NameRoom = "100", PriceRoom = 100 },
                    new ()
                    {Description = "VIP ROOM",Hired = false, ImageRoom = "/.../...",NameRoom = "101",PriceRoom = 200},
                    new ()
                    {Description = "SUPPER VIP ROOM", Hired = false, ImageRoom = "../../", NameRoom = "102", PriceRoom = 300},
                ],
            };
            await dbContext.Admin.AddAsync(admin);
            await dbContext.SaveChangesAsync();
        }
    }
}
