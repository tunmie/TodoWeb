using Microsoft.EntityFrameworkCore;
using TodoWeb.Models;

namespace TodoWeb.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Host=containers-us-west-22.railway.app; Port=6460; Database=railway; Username=postgres; Password=hWzQ3q78TcB6V9hSQoUI";
            optionsBuilder.UseNpgsql(connectionString);
        }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }
    }
}