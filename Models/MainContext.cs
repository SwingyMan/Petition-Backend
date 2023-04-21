using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace WebApplication1.Models
{
    public class MainContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=petition.postgres.database.azure.com;Username=petition;Password=VTEX8K8HV6t3egT;Database=petition");
        }
    }
}
