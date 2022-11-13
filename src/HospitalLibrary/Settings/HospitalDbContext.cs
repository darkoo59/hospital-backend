using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HospitalLibrary.Settings
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<WorkTime> WorkTimes { get; set; }
        public DbSet<BloodRequest> BloodRequests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
               .EnableSensitiveDataLogging();


        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }

        // only for testing purposes
        // ne treba se koristiti za aplikaciju u produkciji
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipment>().HasData(
                new Equipment() { EquipmentType = EquipmentType.Dynamic, Id = 1, RoomId = 1, Name = "Syringe", Quantity = 50 },
                new Equipment() { EquipmentType = EquipmentType.Dynamic, Id = 2, RoomId = 1, Name = "Tounge depressor", Quantity = 32 },
				new Equipment() { EquipmentType = EquipmentType.Dynamic, Id = 3, RoomId = 2, Name = "Gloves", Quantity = 50 },
				new Equipment() { EquipmentType = EquipmentType.Dynamic, Id = 4, RoomId = 2, Name = "Scissors", Quantity = 10 },
				new Equipment() { EquipmentType = EquipmentType.Dynamic, Id = 5, RoomId = 2, Name = "Wheelchairs", Quantity = 2 },
				new Equipment() { EquipmentType = EquipmentType.Dynamic, Id = 6, RoomId = 3, Name = "Scalpel", Quantity = 4 },
				new Equipment() { EquipmentType = EquipmentType.Dynamic, Id = 7, RoomId = 3, Name = "Defibrillator", Quantity = 2 },
				new Equipment() { EquipmentType = EquipmentType.Dynamic, Id = 8, RoomId = 4, Name = "Ultrasound ", Quantity = 1 },
				new Equipment() { EquipmentType = EquipmentType.Dynamic, Id = 9, RoomId = 4, Name = "CT scanner", Quantity = 2 },
				new Equipment() { EquipmentType = EquipmentType.Dynamic, Id = 10, RoomId = 5, Name = "Tounge depressor", Quantity = 12 }

				);
            modelBuilder.Entity<Room>().HasData(
                new Room() { Id = 1, Number = "101A", FloorId = 0, BuildingId = "A", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis", X = 10, Y = 10, Width = 380, Height = 250},
                new Room() { Id = 2, Number = "102A", FloorId = 0, BuildingId = "A", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis1", X = 10, Y = 270, Width = 170, Height = 250 },
                new Room() { Id = 3, Number = "103A", FloorId = 0, BuildingId = "A", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis2", X = 10, Y = 530, Width = 170, Height = 250 },
                new Room() { Id = 4, Number = "104A", FloorId = 0, BuildingId = "A", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis", X = 220, Y = 270, Width = 170, Height = 250 },
                new Room() { Id = 5, Number = "105A", FloorId = 0, BuildingId = "A", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis1", X = 220, Y = 530, Width = 170, Height = 250 },

                new Room() { Id = 6, Number = "201A", FloorId = 1, BuildingId = "A", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis3", X = 10, Y = 10, Width = 380, Height = 250 },
                new Room() { Id = 7, Number = "202A", FloorId = 1, BuildingId = "A", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis4", X = 10, Y = 270, Width = 170, Height = 250 },
                new Room() { Id = 8, Number = "203A", FloorId = 1, BuildingId = "A", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis5", X = 10, Y = 530, Width = 170, Height = 250 },
                new Room() { Id = 9, Number = "204A", FloorId = 1, BuildingId = "A", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis4", X = 220, Y = 270, Width = 170, Height = 250 },
                new Room() { Id = 10, Number = "205A", FloorId = 1, BuildingId = "A", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis5", X = 220, Y = 530, Width = 170, Height = 250 },

                new Room() { Id = 11, Number = "301A", FloorId = 2, BuildingId = "A", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis6", X = 10, Y = 10, Width = 380, Height = 250 },
                new Room() { Id = 12, Number = "302A", FloorId = 2, BuildingId = "A", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis7", X = 10, Y = 270, Width = 170, Height = 250 },
                new Room() { Id = 13, Number = "303A", FloorId = 2, BuildingId = "A", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis8", X = 10, Y = 530, Width = 170, Height = 250 },
                new Room() { Id = 14, Number = "304A", FloorId = 2, BuildingId = "A", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis7", X = 220, Y = 270, Width = 170, Height = 250 },
                new Room() { Id = 15, Number = "305A", FloorId = 2, BuildingId = "A", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis8", X = 220, Y = 530, Width = 170, Height = 250 },

                new Room() { Id = 16, Number = "101B", FloorId = 0, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis", X = 10, Y = 10, Width = 485, Height = 250 },
                new Room() { Id = 17, Number = "102B", FloorId = 0, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis1", X = 505, Y = 10, Width = 480, Height = 250 },
                new Room() { Id = 18, Number = "103B", FloorId = 0, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis2", X = 10, Y = 270, Width = 283, Height = 250 },
                new Room() { Id = 19, Number = "104B", FloorId = 0, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis", X = 10, Y = 530, Width = 283, Height = 250 },
                new Room() { Id = 20, Number = "105B", FloorId = 0, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis1", X = 358, Y = 270, Width = 283, Height = 250 },
                new Room() { Id = 21, Number = "106B", FloorId = 0, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis2", X = 358, Y = 530, Width = 283, Height = 250 },
                new Room() { Id = 22, Number = "107B", FloorId = 0, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis1", X = 706, Y = 270, Width = 282, Height = 250 },
                new Room() { Id = 23, Number = "108B", FloorId = 0, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis2", X = 706, Y = 530, Width = 282, Height = 250 },

                new Room() { Id = 24, Number = "201B", FloorId = 1, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis", X = 10, Y = 10, Width = 485, Height = 250 },
                new Room() { Id = 25, Number = "202B", FloorId = 1, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis1", X = 505, Y = 10, Width = 480, Height = 250 },
                new Room() { Id = 26, Number = "203B", FloorId = 1, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis2", X = 10, Y = 270, Width = 283, Height = 250 },
                new Room() { Id = 27, Number = "204B", FloorId = 1, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis", X = 10, Y = 530, Width = 283, Height = 250 },
                new Room() { Id = 28, Number = "205B", FloorId = 1, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis1", X = 358, Y = 270, Width = 283, Height = 250 },
                new Room() { Id = 29, Number = "206B", FloorId = 1, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis2", X = 358, Y = 530, Width = 283, Height = 250 },
                new Room() { Id = 30, Number = "207B", FloorId = 1, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis1", X = 706, Y = 270, Width = 282, Height = 250 },
                new Room() { Id = 31, Number = "208B", FloorId = 1, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis2", X = 706, Y = 530, Width = 282, Height = 250 },

                new Room() { Id = 32, Number = "301B", FloorId = 2, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis", X = 10, Y = 10, Width = 485, Height = 250 },
                new Room() { Id = 33, Number = "302B", FloorId = 2, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis1", X = 505, Y = 10, Width = 480, Height = 250 },
                new Room() { Id = 34, Number = "303B", FloorId = 2, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis2", X = 10, Y = 270, Width = 283, Height = 250 },
                new Room() { Id = 35, Number = "304B", FloorId = 2, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis", X = 10, Y = 530, Width = 283, Height = 250 },
                new Room() { Id = 36, Number = "305B", FloorId = 2, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis1", X = 358, Y = 270, Width = 283, Height = 250 },
                new Room() { Id = 37, Number = "306B", FloorId = 2, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis2", X = 358, Y = 530, Width = 283, Height = 250 },
                new Room() { Id = 38, Number = "307B", FloorId = 2, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis1", X = 706, Y = 270, Width = 282, Height = 250 },
                new Room() { Id = 39, Number = "308B", FloorId = 2, BuildingId = "B", Type = Core.Enums.RoomType.AppointmentRoom, Description = "neki opis2", X = 706, Y = 530, Width = 282, Height = 250 }

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

            modelBuilder.Entity<BloodRequest>().HasData(

                new BloodRequest() { BloodRequestId = 1, BloodType = BloodType.AB_MINUS, QuantityInLiters = 2.5, ReasonForRequest = "Heart surgery", FinalDate = new System.DateTime(2022, 12, 13), DoctorId = 1 },
                new BloodRequest() { BloodRequestId = 2, BloodType = BloodType.A_PLUS, QuantityInLiters = 3, ReasonForRequest = "Heart surgery", FinalDate = new System.DateTime(2022, 11, 28), DoctorId = 1 },
                new BloodRequest() { BloodRequestId = 3, BloodType = BloodType.O_MINUS, QuantityInLiters = 3.5, ReasonForRequest = "Heart surgery", FinalDate = new System.DateTime(2022, 12, 6), DoctorId = 1 }

            );


            base.OnModelCreating(modelBuilder);
        }
    }
}
