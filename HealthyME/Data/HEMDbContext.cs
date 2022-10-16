using HealthyME.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthyME.Data
{
    public class HEMDbContext : DbContext
    {
        public HEMDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<User> Users { get; set; } = null!;

    }
}
