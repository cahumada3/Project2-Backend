using TeleComApp.Models;
using Microsoft.EntityFrameworkCore;

namespace TeleComApp.Data
{
    public class TCcontext : DbContext
    {
        // Constructor
        public TCcontext(DbContextOptions<TCcontext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
       
        }
    }
}

