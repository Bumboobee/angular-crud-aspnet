using fullstack.api.Models;
using Microsoft.EntityFrameworkCore;

namespace fullstack.api.Data
{
    public class FullStackDbContext : DbContext
    {
        public FullStackDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
