using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Settings
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }

        // only for testing purposes
        // ne treba se koristiti za aplikaciju u produkciji
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasData(
                new Room() { Id = 1, Number = "101A", Floor = 1 },
                new Room() { Id = 2, Number = "204", Floor = 2 },
                new Room() { Id = 3, Number = "305B", Floor = 3 }
            );

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback() { Id = 1, Textt = "Awesome clinic!", User = "Милош", Date = "25.10.2022" },
                new Feedback() { Id = 2, Textt = "It's okay... I guess.", User = "Немања", Date = "25.10.2022" },
                new Feedback() { Id = 3, Textt = "Awful.", User = "Огњен", Date = "25.10.2022" }

            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
