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
                new Room() { Id = 1, Number = "101A", FloorId = 1, BuildingId = "A", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis", X = 10, Y = 10, Width = 380, Height = 250},
                new Room() { Id = 2, Number = "102A", FloorId = 1, BuildingId = "A", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis1", X = 10, Y = 270, Width = 170, Height = 250 },
                new Room() { Id = 3, Number = "103A", FloorId = 1, BuildingId = "A", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis2", X = 10, Y = 530, Width = 170, Height = 250 },
				new Room() { Id = 4, Number = "104A", FloorId = 1, BuildingId = "A", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis", X = 220, Y = 270, Width = 170, Height = 250 },
				new Room() { Id = 5, Number = "105A", FloorId = 1, BuildingId = "A", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis1", X = 220, Y = 530, Width = 170, Height = 250 },

				new Room() { Id = 6, Number = "201A", FloorId = 2, BuildingId = "A", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis3", X = 0, Y = 0, Width = 100, Height = 100 },
                new Room() { Id = 7, Number = "202A", FloorId = 2, BuildingId = "A", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis4", X = 0, Y = 1, Width = 100, Height = 100 },
                new Room() { Id = 8, Number = "203A", FloorId = 2, BuildingId = "A", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis5", X = 0, Y = 2, Width = 100, Height = 100 },
                new Room() { Id = 9, Number = "301A", FloorId = 3, BuildingId = "A", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis6", X = 0, Y = 0, Width = 100, Height = 100 },
                new Room() { Id = 10, Number = "302A", FloorId = 3, BuildingId = "A", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis7", X = 0, Y = 1, Width = 100, Height = 100 },
                new Room() { Id = 11, Number = "303A", FloorId = 3, BuildingId = "A", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis8", X = 0, Y = 2, Width = 100, Height = 100 },

                new Room() { Id = 12, Number = "101B", FloorId = 1, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis", X = 0, Y = 0, Width = 100, Height = 100 },
                new Room() { Id = 13, Number = "102B", FloorId = 1, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis1", X = 0, Y = 1, Width = 100, Height = 100 },
                new Room() { Id = 14, Number = "103B", FloorId = 1, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis2", X = 0, Y = 2, Width = 100, Height = 100 },
                new Room() { Id = 15, Number = "201B", FloorId = 2, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis3", X = 0, Y = 0, Width = 100, Height = 100 },
                new Room() { Id = 16, Number = "202B", FloorId = 2, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis4", X = 0, Y = 1, Width = 100, Height = 100 },
                new Room() { Id = 17, Number = "203B", FloorId = 2, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis5", X = 0, Y = 2, Width = 100, Height = 100 },
                new Room() { Id = 18, Number = "301B", FloorId = 3, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis6", X = 0, Y = 0, Width = 100, Height = 100 },
                new Room() { Id = 19, Number = "302B", FloorId = 3, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis7", X = 0, Y = 1, Width = 100, Height = 100 },
                new Room() { Id = 20, Number = "303B", FloorId = 3, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis8", X = 0, Y = 2, Width = 100, Height = 100 }
          );

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback() {Id = "1", Text = "Awesome clinic!", User = "Милош", Date = "25.10.2022" },
                new Feedback() {Id = "2", Text = "It's okay... I guess.", User = "Немања", Date = "25.10.2022" },
                new Feedback() {Id = "3", Text = "Awful.", User = "Огњен", Date = "25.10.2022" }

            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
