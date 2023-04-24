using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace WebApplication1.Models
{
    public class MainContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Petition> Petitions { get; set; }
        public DbSet<Documentation> Documentation { get; set; }
        public DbSet<Supports> Supports { get; set; }
        public DbSet<toWho> ToWho { get; set; }
        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<Sketch> sketches { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=petition.postgres.database.azure.com;Username=petition;Password=VTEX8K8HV6t3egT;Database=petition");
        }
    }
}
