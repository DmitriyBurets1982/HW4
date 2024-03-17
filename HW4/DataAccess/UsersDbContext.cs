using HW4.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HW4.DataAccess
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions options)
            : base(options)
        {
            Console.WriteLine($"Connection string: '{Database.GetConnectionString()}'");
            Database.Migrate();
        }

        public DbSet<User> Users { get; set; }
    }
}
