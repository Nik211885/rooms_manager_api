using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Data
{
    public class RoomsManagerDbConText : DbContext
    {
        public RoomsManagerDbConText(DbContextOptions<RoomsManagerDbConText> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Bill> Bills { get; set; }  
        public DbSet<Contract> Contracts { get; set; }  
        public DbSet<Message> Messages { get; set; }    
        public DbSet<ServicesBases> ServicesBases { get; set; } 
        public DbSet<ServicesCustom> ServicesCustoms { get; set; }  
        public DbSet<ServiceSupport> ServicesSupport { get; set; } 
        public DbSet<Room> Rooms { get; set; }  
        public DbSet<Notify> Notifies { get; set; }
    }
}
