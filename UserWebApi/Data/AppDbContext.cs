

using Microsoft.EntityFrameworkCore;
using UserWebApi.Models;
namespace EntityframeworkCore.MySql.Data
{
    public class AppDbContext : DbContext  // DbContext class for interacting with the database
    {

        //constructor 

        public AppDbContext(DbContextOptions options) : base(options) { }


        public DbSet<User> Users { get; set; }  // DbSet property representing the 'Users' table in the database

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(r => r.username);  // Configuring the primary key for the 'User' entity based on the 'username' property
        }
    }
}
