using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Features.BloodBankNews.Model;
using Microsoft.EntityFrameworkCore;

namespace IntegrationLibrary.Settings
{
    public class IntegrationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<BankNews> BankNews { get; set; }

        public IntegrationDbContext(DbContextOptions<IntegrationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, Email = "email1@gmail.com", AppName = "app1", Password = "OLIfDWaYYunpFtiQ", Server = "localhost:5555" },
                new User() { Id = 2, Email = "email2@gmail.com", AppName = "app2", Password = "UzX1V1A0FfLerVn5", Server = "localhost:6555" },
                new User() { Id = 3, Email = "email3@gmail.com", AppName = "app3", Password = "dd13xfCA5Jz9Y9ho", Server = "localhost:7555" }
            );
            modelBuilder.Entity<BankNews>().HasData(
                new BankNews() { Id = 1, Title = "vijest 1", Content = "sadrzaj vijesti 1" },
                new BankNews() { Id = 2, Title = "vijest 2", Content = "sadrzaj vijesti 2" },
                new BankNews() { Id = 3, Title = "vijest 3", Content = "sadrzaj vijesti 3" }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
