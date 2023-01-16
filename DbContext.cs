using EFCoreInMemoryDbDemo;
using Microsoft.EntityFrameworkCore;
namespace EFCoreInMemoryDbDemo
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "UserDb");
        }
        public DbSet<User> Users { get; set; }
    }
}