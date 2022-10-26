using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Settings
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasData(
                new Room() { Id = 1, Number = "101A", FloorId = 1 },
                new Room() { Id = 2, Number = "204", FloorId = 2 },
                new Room() { Id = 3, Number = "305B", FloorId = 3 }
            );

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback() { Text = "Awesome clinic!", User = "Милош", Date = "25.10.2022" },
                new Feedback() { Text = "It's okay... I guess.", User = "Немања", Date = "25.10.2022" },
                new Feedback() { Text = "Awful.", User = "Огњен", Date = "25.10.2022" }

            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
