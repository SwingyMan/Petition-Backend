using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace PetitionBackend.Models
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
            IConfigurationRoot configuration = new ConfigurationBuilder()
.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
.AddJsonFile("appsettings.json")
.Build();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("PetitionDatabase"));
        }
    }
}
