using Microsoft.EntityFrameworkCore;
using StudentWebApi.Models;

namespace StudentWebApi
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=TestDataBase;Username=postgres;Password=pgadmin");
    }
}
