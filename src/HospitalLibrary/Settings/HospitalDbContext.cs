using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Settings
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<WorkTime> WorkTimes { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }

        // only for testing purposes
        // ne treba se koristiti za aplikaciju u produkciji
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
                new Room() { Id = 14, Number = "10x3B", FloorId = 1, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis2", X = 0, Y = 2, Width = 100, Height = 100 },
                new Room() { Id = 15, Number = "201B", FloorId = 2, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis3", X = 0, Y = 0, Width = 100, Height = 100 },
                new Room() { Id = 16, Number = "202B", FloorId = 2, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis4", X = 0, Y = 1, Width = 100, Height = 100 },
                new Room() { Id = 17, Number = "203B", FloorId = 2, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis5", X = 0, Y = 2, Width = 100, Height = 100 },
                new Room() { Id = 18, Number = "301B", FloorId = 3, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis6", X = 0, Y = 0, Width = 100, Height = 100 },
                new Room() { Id = 19, Number = "302B", FloorId = 3, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis7", X = 0, Y = 1, Width = 100, Height = 100 },
                new Room() { Id = 20, Number = "303B", FloorId = 3, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis8", X = 0, Y = 2, Width = 100, Height = 100 }
          );


            modelBuilder.Entity<Patient>().HasData(
                new Patient() { PatientId = 1, Name = "Pera", Surname = "Peric" },
                new Patient() { PatientId = 2, Name = "Marko", Surname = "Markovic" },
                new Patient() { PatientId = 3, Name = "Aleksa", Surname = "Aleksic" }
            );

            modelBuilder.Entity<Specialization>().HasData(
               new Specialization() { SpecializationId = 1, Name = "Anesthesiology" },
               new Specialization() { SpecializationId = 2, Name = "Dermatology" },
               new Specialization() { SpecializationId = 3, Name = "Family medicine" }
           );

            modelBuilder.Entity<Doctor>().HasData(
               new Doctor() { DoctorId = 1, Name = "Ognjen", Surname = "Nikolic", SpecializationId = 3, RoomId = 1 }
               /*new Doctor() { Id = 2, Name = "Mika", Surname = "Mikic", SpecializationId = 3, RoomId = 2 },
               new Doctor() { Id = 3, Name = "Aleksa", Surname = "Santic", SpecializationId = 3, RoomId = 1 }*/
           );

            modelBuilder.Entity<Appointment>().HasData(
               new Appointment() { AppointmentId = 1, Start = System.DateTime.Now, DoctorId = 1, PatientId = 1 }
           );

            modelBuilder.Entity<WorkTime>().HasData(
               new WorkTime() { WorkTimeId = 1, StartDate = new System.DateTime(2022, 10, 15), EndDate = new System.DateTime(2022, 11, 15), StartTime = new System.TimeSpan(8, 0, 0), EndTime = new System.TimeSpan(16, 0, 0), DoctorId = 1 }
           );

            modelBuilder.Entity<Vacation>().HasData(
              new Vacation() { VacationId = 1, StartDate = new System.DateTime(2022, 11, 17), EndDate = new System.DateTime(2022, 12, 2), DoctorId = 1 }
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
