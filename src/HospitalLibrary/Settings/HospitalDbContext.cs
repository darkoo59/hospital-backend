using System;
using HospitalLibrary.Core.Model;
using HospitalLibrary.EventSourcing.Infrastructure;
using HospitalLibrary.EventSourcing.Model.ExaminationEvents;
using HospitalLibrary.Feedbacks.Model;
using HospitalLibrary.HospitalMap.Enums;
using HospitalLibrary.HospitalMap.Model;
using HospitalLibrary.RenovationEventSourcing;
using HospitalLibrary.SharedModel;
using Microsoft.EntityFrameworkCore;


namespace HospitalLibrary.Settings
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Allergen> Allergens { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        //public DbSet<WorkTime> WorkTimes { get; set; }
        public DbSet<BloodRequest> BloodRequests { get; set; }
        public DbSet<Bed> Beds { get; set; }
        public DbSet<VacationRequest> VacationRequests { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Blood> Bloods { get; set; }
        public DbSet<BloodUsageEvidency> BloodUsageEvidencies { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<BloodTherapy> BloodTherapies { get; set; }
        public DbSet<MedicineTherapy> MedicineTherapies { get; set; }
        public DbSet<InpatientTreatment> InpatientTreatments { get; set; }
        public DbSet<InpatientTreatmentTherapy> InpatientTreatmentTherapies { get; set; }
        public DbSet<PhysicianSchedule> PhysicianSchedules { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<ExaminationReport> ExaminationReports { get; set; }
        public DbSet<Consilium> Consiliums { get; set; }
        public DbSet<MoveRequest> MoveRequests { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventStream> EventStreams { get; set; }
        public DbSet<EventWrapper> EventWrappers { get; set; }
        public DbSet<ExaminationFinished> ExaminationFinishedEvents { get; set; }
        public DbSet<ExaminationStarted> ExaminationStartedEvents { get; set; }
        public DbSet<RecipesCreated> RecipesCreatedEvents { get; set; }
        public DbSet<ReportEntered> ReportEnteredEvents { get; set; }
        public DbSet<SymptomsSelected> SymptomsSelectedEvents { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
               .EnableSensitiveDataLogging();



        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }

        // only for testing purposes
        // ne treba se koristiti za aplikaciju u produkciji
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Database.SetInitializer<HospitalDbContext>(null);

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
                new Room() { Id = 1, Number = "101A", FloorId = 0, BuildingId = "A", Type = RoomType.AppointmentRoom, Description = "neki opis", X = 10, Y = 10, Width = 380, Height = 250},
                new Room() { Id = 2, Number = "102A", FloorId = 0, BuildingId = "A", Type = RoomType.AppointmentRoom, Description = "neki opis1", X = 10, Y = 270, Width = 170, Height = 250 },
                new Room() { Id = 3, Number = "103A", FloorId = 0, BuildingId = "A", Type = RoomType.AppointmentRoom, Description = "neki opis2", X = 10, Y = 530, Width = 170, Height = 250 },
                new Room() { Id = 4, Number = "104A", FloorId = 0, BuildingId = "A", Type = RoomType.AppointmentRoom, Description = "neki opis", X = 220, Y = 270, Width = 170, Height = 250 },
                new Room() { Id = 5, Number = "105A", FloorId = 0, BuildingId = "A", Type = RoomType.AppointmentRoom, Description = "neki opis1", X = 220, Y = 530, Width = 170, Height = 250 },

                new Room() { Id = 6, Number = "201A", FloorId = 1, BuildingId = "A", Type = RoomType.AppointmentRoom, Description = "neki opis3", X = 10, Y = 10, Width = 380, Height = 250 },
                new Room() { Id = 7, Number = "202A", FloorId = 1, BuildingId = "A", Type = RoomType.AppointmentRoom, Description = "neki opis4", X = 10, Y = 270, Width = 170, Height = 250 },
                new Room() { Id = 8, Number = "203A", FloorId = 1, BuildingId = "A", Type = RoomType.AppointmentRoom, Description = "neki opis5", X = 10, Y = 530, Width = 170, Height = 250 },
                new Room() { Id = 9, Number = "204A", FloorId = 1, BuildingId = "A", Type = RoomType.AppointmentRoom, Description = "neki opis4", X = 220, Y = 270, Width = 170, Height = 250 },
                new Room() { Id = 10, Number = "205A", FloorId = 1, BuildingId = "A", Type = RoomType.AppointmentRoom, Description = "neki opis5", X = 220, Y = 530, Width = 170, Height = 250 },

                new Room() { Id = 11, Number = "301A", FloorId = 2, BuildingId = "A", Type = RoomType.AppointmentRoom, Description = "neki opis6", X = 10, Y = 10, Width = 380, Height = 250 },
                new Room() { Id = 12, Number = "302A", FloorId = 2, BuildingId = "A", Type = RoomType.AppointmentRoom, Description = "neki opis7", X = 10, Y = 270, Width = 170, Height = 250 },
                new Room() { Id = 13, Number = "303A", FloorId = 2, BuildingId = "A", Type = RoomType.AppointmentRoom, Description = "neki opis8", X = 10, Y = 530, Width = 170, Height = 250 },
                new Room() { Id = 14, Number = "304A", FloorId = 2, BuildingId = "A", Type = RoomType.AppointmentRoom, Description = "neki opis7", X = 220, Y = 270, Width = 170, Height = 250 },
                new Room() { Id = 15, Number = "305A", FloorId = 2, BuildingId = "A", Type = RoomType.AppointmentRoom, Description = "neki opis8", X = 220, Y = 530, Width = 170, Height = 250 },

                new Room() { Id = 16, Number = "101B", FloorId = 0, BuildingId = "B", Type = RoomType.AppointmentRoom, Description = "neki opis", X = 10, Y = 10, Width = 485, Height = 250 },
                new Room() { Id = 17, Number = "102B", FloorId = 0, BuildingId = "B", Type = RoomType.AppointmentRoom, Description = "neki opis1", X = 505, Y = 10, Width = 480, Height = 250 },
                new Room() { Id = 18, Number = "103B", FloorId = 0, BuildingId = "B", Type = RoomType.AppointmentRoom, Description = "neki opis2", X = 10, Y = 270, Width = 283, Height = 250 },
                new Room() { Id = 19, Number = "104B", FloorId = 0, BuildingId = "B", Type = RoomType.AppointmentRoom, Description = "neki opis", X = 10, Y = 530, Width = 283, Height = 250 },
                new Room() { Id = 20, Number = "105B", FloorId = 0, BuildingId = "B", Type = RoomType.AppointmentRoom, Description = "neki opis1", X = 358, Y = 270, Width = 283, Height = 250 },
                new Room() { Id = 21, Number = "106B", FloorId = 0, BuildingId = "B", Type = RoomType.AppointmentRoom, Description = "neki opis2", X = 358, Y = 530, Width = 283, Height = 250 },
                new Room() { Id = 22, Number = "107B", FloorId = 0, BuildingId = "B", Type = RoomType.AppointmentRoom, Description = "neki opis1", X = 706, Y = 270, Width = 282, Height = 250 },
                new Room() { Id = 23, Number = "108B", FloorId = 0, BuildingId = "B", Type = RoomType.AppointmentRoom, Description = "neki opis2", X = 706, Y = 530, Width = 282, Height = 250 },

                new Room() { Id = 24, Number = "201B", FloorId = 1, BuildingId = "B", Type = RoomType.AppointmentRoom, Description = "neki opis", X = 10, Y = 10, Width = 485, Height = 250 },
                new Room() { Id = 25, Number = "202B", FloorId = 1, BuildingId = "B", Type = RoomType.AppointmentRoom, Description = "neki opis1", X = 505, Y = 10, Width = 480, Height = 250 },
                new Room() { Id = 26, Number = "203B", FloorId = 1, BuildingId = "B", Type = RoomType.AppointmentRoom, Description = "neki opis2", X = 10, Y = 270, Width = 283, Height = 250 },
                new Room() { Id = 27, Number = "204B", FloorId = 1, BuildingId = "B", Type = RoomType.AppointmentRoom, Description = "neki opis", X = 10, Y = 530, Width = 283, Height = 250 },
                new Room() { Id = 28, Number = "205B", FloorId = 1, BuildingId = "B", Type = RoomType.AppointmentRoom, Description = "neki opis1", X = 358, Y = 270, Width = 283, Height = 250 },
                new Room() { Id = 29, Number = "206B", FloorId = 1, BuildingId = "B", Type = RoomType.AppointmentRoom, Description = "neki opis2", X = 358, Y = 530, Width = 283, Height = 250 },
                new Room() { Id = 30, Number = "207B", FloorId = 1, BuildingId = "B", Type = RoomType.AppointmentRoom, Description = "neki opis1", X = 706, Y = 270, Width = 282, Height = 250 },
                new Room() { Id = 31, Number = "208B", FloorId = 1, BuildingId = "B", Type = RoomType.AppointmentRoom, Description = "neki opis2", X = 706, Y = 530, Width = 282, Height = 250 },

                new Room() { Id = 32, Number = "301B", FloorId = 2, BuildingId = "B", Type = RoomType.AppointmentRoom, Description = "neki opis", X = 10, Y = 10, Width = 485, Height = 250 },
                new Room() { Id = 33, Number = "302B", FloorId = 2, BuildingId = "B", Type = RoomType.AppointmentRoom, Description = "neki opis1", X = 505, Y = 10, Width = 480, Height = 250 },
                new Room() { Id = 34, Number = "303B", FloorId = 2, BuildingId = "B", Type = RoomType.AppointmentRoom, Description = "neki opis2", X = 10, Y = 270, Width = 283, Height = 250 },
                new Room() { Id = 35, Number = "304B", FloorId = 2, BuildingId = "B", Type = RoomType.AppointmentRoom, Description = "neki opis", X = 10, Y = 530, Width = 283, Height = 250 },
                new Room() { Id = 36, Number = "305B", FloorId = 2, BuildingId = "B", Type = RoomType.AppointmentRoom, Description = "neki opis1", X = 358, Y = 270, Width = 283, Height = 250 },
                new Room() { Id = 37, Number = "306B", FloorId = 2, BuildingId = "B", Type = RoomType.AppointmentRoom, Description = "neki opis2", X = 358, Y = 530, Width = 283, Height = 250 },
                new Room() { Id = 38, Number = "307B", FloorId = 2, BuildingId = "B", Type = RoomType.AppointmentRoom, Description = "neki opis1", X = 706, Y = 270, Width = 282, Height = 250 },
                new Room() { Id = 39, Number = "308B", FloorId = 2, BuildingId = "B", Type = RoomType.AppointmentRoom, Description = "neki opis2", X = 706, Y = 530, Width = 282, Height = 250 }

          );


            modelBuilder.Entity<Allergen>().HasData(
                new Allergen() { AllergenId = 1, Name = "Peanuts"},
                new Allergen() { AllergenId = 2, Name = "Dust"},
                new Allergen() { AllergenId = 3, Name = "Fungal spores"},
                new Allergen() { AllergenId = 4, Name = "Insect and mite feces" },
                new Allergen() { AllergenId = 5, Name = "Insect bites and stinges (their venom)" },
                new Allergen() { AllergenId = 6, Name = "Pollen" },
                new Allergen() { AllergenId = 7, Name = "Milk and/or dairy products" },
                new Allergen() { AllergenId = 8, Name = "Eggs" },
                new Allergen() { AllergenId = 9, Name = "Wheat" }
            );

            modelBuilder.Entity<Allergen>().HasMany(a => a.MedicalRecords).WithMany(mr => mr.Allergens);

            modelBuilder.Entity<MedicalRecord>().HasData(
                new MedicalRecord() { Id = 1, BloodType = BloodType.A_PLUS, Allergens = { } },
                new MedicalRecord() { Id = 2, BloodType = BloodType.O_PLUS, Allergens = { } },
                new MedicalRecord() { Id = 3, BloodType = BloodType.AB_MINUS, Allergens = { } },
                new MedicalRecord() { Id = 4, BloodType = BloodType.B_PLUS, Allergens = { } },
                new MedicalRecord() { Id = 5, BloodType = BloodType.O_MINUS, Allergens = { } },
                new MedicalRecord() { Id = 6, BloodType = BloodType.A_MINUS, Allergens = { } },
                new MedicalRecord() { Id = 7, BloodType = BloodType.AB_PLUS, Allergens = { } },
                new MedicalRecord() { Id = 8, BloodType = BloodType.O_MINUS, Allergens = { } },
                new MedicalRecord() { Id = 9, BloodType = BloodType.B_MINUS, Allergens = { } }
            );
            
            modelBuilder.Entity<MedicalRecord>().HasMany(mr => mr.Allergens).WithMany(a => a.MedicalRecords);

            modelBuilder.Entity<Patient>().HasData(
                new Patient() { PatientId = 1, Name = "Pera", Surname = "Peric", IsAccountActivated = false, MedicalRecord = 1},
                new Patient() {PatientId = 2, Name = "Marko", Surname = "Markovic", IsAccountActivated = false, MedicalRecord = 2 },
                new Patient() {PatientId = 3, Name = "Aleksa", Surname = "Aleksic", IsAccountActivated = false, MedicalRecord = 3 },
                new Patient() {PatientId = 4, Name = "Pera", Surname = "Peric", IsAccountActivated = false, MedicalRecord = 4 },
                new Patient() {PatientId = 5, Name = "Marko", Surname = "Markovic", IsAccountActivated = false, MedicalRecord = 5 },
                new Patient() {PatientId = 6, Name = "Aleksa", Surname = "Aleksic", IsAccountActivated = false, MedicalRecord = 6 },
                new Patient() {PatientId = 7, Name = "Pera", Surname = "Peric", IsAccountActivated = false, MedicalRecord = 7 },
                new Patient() {PatientId = 8, Name = "Marko", Surname = "Markovic", IsAccountActivated = false, MedicalRecord = 8 },
                new Patient() {PatientId = 9, Name = "Aleksa", Surname = "Aleksic", IsAccountActivated = false, MedicalRecord = 9 }
            );

            modelBuilder.Entity<Patient>().HasMany(p => p.Doctors).WithMany(dr => dr.Patients);

            modelBuilder.Entity<Doctor>().HasData(
               new Doctor() { DoctorId = 1, Name = "Ognjen", Surname = "Nikolic", SpecializationId = 3, RoomId = 1},
               new Doctor() { DoctorId = 2, Name = "Mika", Surname = "Mikic", SpecializationId = 1, RoomId = 2},
               new Doctor() { DoctorId = 3, Name = "Aleksa", Surname = "Santic", SpecializationId = 2, RoomId = 1 },
               new Doctor() { DoctorId = 4, Name = "Nikola", Surname = "Peric", SpecializationId = 3, RoomId = 1 }
           );
            
            modelBuilder.Entity<Doctor>().HasMany(dr => dr.Patients).WithMany(p => p.Doctors);
            
            modelBuilder.Entity<Specialization>().HasData(
               new Specialization() { SpecializationId = 1, Name = "Anesthesiology" },
               new Specialization() { SpecializationId = 2, Name = "Dermatology" },
               new Specialization() { SpecializationId = 3, Name = "Family medicine" }
           );

           // modelBuilder.Entity<Appointment>().HasData(
           //    new Appointment() { AppointmentId = 1, Start = System.DateTime.Now, DoctorId = 1, PatientId = 1 }
           //);

          //  modelBuilder.Entity<WorkTime>().HasData(
          //     new WorkTime() { WorkTimeId = 1, StartDate = new System.DateTime(2022, 10, 15), EndDate = new System.DateTime(2022, 11, 15), StartTime = new System.TimeSpan(8, 0, 0), EndTime = new System.TimeSpan(16, 0, 0), DoctorId = 1 }
          // );

          //  modelBuilder.Entity<Vacation>().HasData(
          //    new Vacation() { VacationId = 1, StartDate = new System.DateTime(2022, 11, 17), EndDate = new System.DateTime(2022, 12, 2), DoctorId = 1 }
          //);

            modelBuilder.Entity<Feedback>().HasData(

                new Feedback() { Id = 1, Textt = "Awesome clinic!", PatientId = 5, Date = "25.10.2022" },
                new Feedback() { Id = 2, Textt = "It's okay... I guess.", PatientId = 5, Date = "25.10.2022" },
                new Feedback() { Id = 3, Textt = "Awful.", PatientId = 5, Date = "25.10.2022" }

            );

            modelBuilder.Entity<BloodRequest>().HasData(

                new BloodRequest() { BloodRequestId = 1, BloodType = BloodType.AB_MINUS, QuantityInLiters = 2.5, ReasonForRequest = "Heart surgery", FinalDate = new System.DateTime(2022, 12, 13), DoctorId = 1 },
                new BloodRequest() { BloodRequestId = 2, BloodType = BloodType.A_PLUS, QuantityInLiters = 3, ReasonForRequest = "Heart surgery", FinalDate = new System.DateTime(2022, 11, 28), DoctorId = 1 },
                new BloodRequest() { BloodRequestId = 3, BloodType = BloodType.O_MINUS, QuantityInLiters = 3.5, ReasonForRequest = "Heart surgery", FinalDate = new System.DateTime(2022, 12, 6), DoctorId = 1 }

            );

            modelBuilder.Entity<Bed>().HasData(

                new Bed() { BedId = 1, Label = "201B1", IsAvailable = false },
                new Bed() { BedId = 2, Label = "201B2", IsAvailable = true },
                new Bed() { BedId = 3, Label = "201B3", IsAvailable = true }

            );

            modelBuilder.Entity<VacationRequest>().HasData(
                
                new VacationRequest() { VacationRequestId = 1 , StartDate = DateTime.Now.AddDays(10),EndDate = DateTime.Now.AddDays(15),DoctorId = 4 , Status = Core.Enums.VacationRequestStatus.Approved, Urgency = "NoUrgent" , Reason = "Tired"},
                new VacationRequest() { VacationRequestId = 2, StartDate = DateTime.Now.AddDays(15), EndDate = DateTime.Now.AddDays(20), DoctorId = 4, Status = Core.Enums.VacationRequestStatus.OnHold, Urgency = "Urgent", Reason = "Tired" },
                new VacationRequest() { VacationRequestId = 3, StartDate = DateTime.Now.AddDays(20), EndDate = DateTime.Now.AddDays(25), DoctorId = 4, Status = Core.Enums.VacationRequestStatus.NotApproved, Urgency = "NoUrgent", Reason = "Tired" }
                );


            modelBuilder.Entity<Blood>().HasData(

               new Blood() { BloodId = 1, BloodType = BloodType.O_PLUS, QuantityInLiters = 4 } ,
               new Blood() { BloodId = 2, BloodType = BloodType.A_PLUS, QuantityInLiters = 4 },
               new Blood() { BloodId = 3, BloodType = BloodType.B_PLUS, QuantityInLiters = 4 },
               new Blood() { BloodId = 4, BloodType = BloodType.AB_PLUS, QuantityInLiters = 4 },
               new Blood() { BloodId = 5, BloodType = BloodType.O_MINUS, QuantityInLiters = 4 },
               new Blood() { BloodId = 6, BloodType = BloodType.A_MINUS, QuantityInLiters = 4 },
               new Blood() { BloodId = 7, BloodType = BloodType.B_MINUS, QuantityInLiters = 4 },
               new Blood() { BloodId = 8, BloodType = BloodType.AB_MINUS, QuantityInLiters = 4 }


             );

            modelBuilder.Entity<BloodUsageEvidency>().HasData(

               new BloodUsageEvidency() { BloodUsageEvidencyId=1 , BloodType = BloodType.A_PLUS, QuantityUsedInMililiters=200 , DateOfUsage = new System.DateTime(2022, 12, 13) , ReasonForUsage= "Hearth surgery" ,DoctorId = 1},
                new BloodUsageEvidency() { BloodUsageEvidencyId = 2, BloodType = BloodType.B_MINUS, QuantityUsedInMililiters = 300, DateOfUsage = new System.DateTime(2022, 11, 13), ReasonForUsage = "Hearth surgery", DoctorId = 1 },
               new BloodUsageEvidency() { BloodUsageEvidencyId = 3, BloodType = BloodType.O_PLUS, QuantityUsedInMililiters = 450, DateOfUsage = new System.DateTime(2022, 11, 8), ReasonForUsage = "Hearth surgery", DoctorId = 1 },
               new BloodUsageEvidency() { BloodUsageEvidencyId = 4, BloodType = BloodType.A_PLUS, QuantityUsedInMililiters = 700, DateOfUsage = new System.DateTime(2022, 11, 17), ReasonForUsage = "Hearth surgery", DoctorId = 1 },
               new BloodUsageEvidency() { BloodUsageEvidencyId = 5, BloodType = BloodType.B_MINUS, QuantityUsedInMililiters = 180, DateOfUsage = new System.DateTime(2022, 5, 13), ReasonForUsage = "Hearth surgery", DoctorId = 1 },
               new BloodUsageEvidency() { BloodUsageEvidencyId = 6, BloodType = BloodType.AB_MINUS, QuantityUsedInMililiters = 1100, DateOfUsage = new System.DateTime(2022, 12, 13), ReasonForUsage = "Hearth surgery", DoctorId = 1 }
            );

            modelBuilder.Entity<Medicine>().HasData(

                new Medicine() { MedicineId = 1, Name = "Aspirin", Manufacturer = "Galenika" },
                new Medicine() { MedicineId = 2, Name = "Bromazepam", Manufacturer = "Hemofarm" },
                new Medicine() { MedicineId = 3, Name = "Caffetin", Manufacturer = "Hemofarm" }

            );

            modelBuilder.Entity<InpatientTreatment>().HasData(

               new InpatientTreatment() { InpatientTreatmentId = 1, PatientId = 1, ReasonForAdmission = "Headache", RoomId = 21, BedId = 1, DateOfAdmission = new System.DateTime(2022, 11, 18) }
           );

            modelBuilder.Entity<InpatientTreatmentTherapy>().HasData(

               new InpatientTreatmentTherapy() { InpatientTreatmentTherapyId = 1, InpatientTreatmentId = 1 }
           );
            modelBuilder.Entity<User>().HasData(
                new User() { UserId = 1, Email = "doctor1", Password = "doctor1", Role = UserRole.doctor },
                new User() { UserId = 2, Email = "doctor2", Password = "doctor2", Role = UserRole.doctor },
                new User() { UserId = 3, Email = "doctor3", Password = "doctor3", Role = UserRole.doctor },
                new User() { UserId = 4, Email = "doctor4", Password = "doctor4", Role = UserRole.doctor },
                new User() { UserId = 5, Email = "email", Password = "password", Role = UserRole.patient }
            );

            modelBuilder.Entity<PhysicianSchedule>()
                .Property(b => b.WorkTimes)
                .HasColumnType("jsonb");

            
            
            modelBuilder.Entity<Symptom>().HasData(
               new Symptom() { SymptomId = 1, Name = "High blood presure" },
               new Symptom() { SymptomId = 2, Name = "Sore throat" },
               new Symptom() { SymptomId = 3, Name = "Elevated body temperature" }
           );
            modelBuilder.Entity<Vacation>().HasKey(v => v.Id);
            modelBuilder.Entity<Appointment>().HasKey(v => v.Id);
            modelBuilder.Entity<ExaminationReport>().HasKey(v => v.Id);
            modelBuilder.Entity<PhysicianSchedule>().HasKey(v => v.Id);


            modelBuilder.Entity<Appointment>()
                .Property(b => b.ScheduledDate)
                .HasColumnType("jsonb");

            modelBuilder.Entity<Consilium>()
                .Property(b => b.DateRange)
                .HasColumnType("jsonb");

            //modelBuilder.Entity<MoveRequest>().HasKey(m => m.fromRoomId);
            modelBuilder.Entity<MoveRequest>().HasData(
                new MoveRequest() {id = 1, type="EquipmentMove", fromRoomId = 1, toRoomId = 2, chosenStartTime = new System.DateTime(2022,12,10,15,0,0), duration = new System.TimeSpan(0, 30, 0), equipment = "Syringe", quantity = 2 }
            );


            base.OnModelCreating(modelBuilder);
        }
    }
}