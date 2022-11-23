using HospitalAPI;
using HospitalLibrary.Core.Model;
using HospitalLibrary.HospitalMap.Enums;
using HospitalLibrary.HospitalMap.Model;
using HospitalLibrary.Settings;
using HospitalLibrary.SharedModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace HospitalTests.setup
{
    public class TestDatabaseFactory<TStartup> : WebApplicationFactory<Startup>
    {
      

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                using var scope = BuildServiceProvider(services).CreateScope();
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<HospitalDbContext>();
                InitializeDatabase(db);
                   
            });
        }

        private static ServiceProvider BuildServiceProvider(IServiceCollection services)
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<HospitalDbContext>));
            services.Remove(descriptor);

            services.AddDbContext<HospitalDbContext>(opt => opt.UseNpgsql(CreateConnectionStringForTest()));
            return services.BuildServiceProvider();
        }

        private static string CreateConnectionStringForTest()
        {
            return "Host=localhost;Database=HospitalTestDb;Username=postgres;Password=password;";
        }

        private static void InitializeDatabase(HospitalDbContext context)
        {
           
            context.Database.EnsureCreated();

            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"BloodRequests\";");
            //context.BloodRequests.Add(new BloodRequest() { BloodRequestId = 1, BloodType = BloodType.AB_MINUS, QuantityInLiters = 2.5, ReasonForRequest = "Heart surgery", FinalDate = new System.DateTime(2022, 12, 13), DoctorId = 1 });
            //context.BloodRequests.Add(new BloodRequest() { BloodRequestId = 2, BloodType = BloodType.A_PLUS, QuantityInLiters = 3, ReasonForRequest = "Heart surgery", FinalDate = new System.DateTime(2022, 11, 28), DoctorId = 1 });
            //context.BloodRequests.Add(new BloodRequest() { BloodRequestId = 3, BloodType = BloodType.O_MINUS, QuantityInLiters = 3.5, ReasonForRequest = "Heart surgery", FinalDate = new System.DateTime(2022, 12, 6), DoctorId = 1 });
            
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"VacationRequests\";");
            context.VacationRequests.Add (new VacationRequest { VacationRequestId = 1, StartDate = DateTime.Now.AddDays(10), EndDate = DateTime.Now.AddDays(15), DoctorId = 1, Status = HospitalLibrary.Core.Enums.VacationRequestStatus.NotApproved, Urgency = "NoUrgent" });
            context.VacationRequests.Add(new VacationRequest { VacationRequestId = 2, StartDate = DateTime.Now.AddDays(3), EndDate = DateTime.Now.AddDays(13), DoctorId = 2, Status = HospitalLibrary.Core.Enums.VacationRequestStatus.Approved, Urgency = "Urgent" });
            context.VacationRequests.Add(new VacationRequest { VacationRequestId = 3, StartDate = DateTime.Now.AddDays(20), EndDate = DateTime.Now.AddDays(25), DoctorId = 3, Status = HospitalLibrary.Core.Enums.VacationRequestStatus.OnHold, Urgency = "NoUrgent" });

                
              context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Bloods\";");
            
              context.Bloods.Add(new Blood() { BloodId = 1, BloodType = BloodType.O_PLUS, QuantityInLiters = 4 });
              context.Bloods.Add(new Blood() { BloodId = 2, BloodType = BloodType.A_PLUS, QuantityInLiters = 4 });
              context.Bloods.Add(new Blood() { BloodId = 3, BloodType = BloodType.B_PLUS, QuantityInLiters = 4 });
              context.Bloods.Add(new Blood() { BloodId = 4, BloodType = BloodType.AB_PLUS, QuantityInLiters = 4 });
              context.Bloods.Add(new Blood() { BloodId = 5, BloodType = BloodType.O_MINUS, QuantityInLiters = 4 });
              context.Bloods.Add(new Blood() { BloodId = 6, BloodType = BloodType.A_MINUS, QuantityInLiters = 4 });
              context.Bloods.Add(new Blood() { BloodId = 7, BloodType = BloodType.B_MINUS, QuantityInLiters = 4 });
              context.Bloods.Add(new Blood() { BloodId = 8, BloodType = BloodType.AB_MINUS, QuantityInLiters = 4 });
         

            context.Database.ExecuteSqlRaw("TRUNCATE TABLE  \"BloodUsageEvidencies\";");

         //   context.BloodUsageEvidencies.Add(new BloodUsageEvidency() { BloodUsageEvidencyId = 1, BloodType = BloodType.A_PLUS, QuantityUsedInMililiters = 200, DateOfUsage = new System.DateTime(2022, 12, 13), ReasonForUsage = "Hearth surgery", DoctorId = 1 });

            context.Database.ExecuteSqlRaw("TRUNCATE TABLE  \"Equipment\";");

            context.Equipment.Add(new Equipment() { EquipmentType = EquipmentType.Dynamic, Id = 1, RoomId = 1, Name = "Syringe", Quantity = 50 });
            context.Equipment.Add(new Equipment() { EquipmentType = EquipmentType.Dynamic, Id = 2, RoomId = 1, Name = "Tounge depressor", Quantity = 32 });
            context.Equipment.Add(new Equipment() { EquipmentType = EquipmentType.Dynamic, Id = 3, RoomId = 2, Name = "Gloves", Quantity = 50 });

/*            context.Database.ExecuteSqlRaw("DROP TABLE  \"Beds\";");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE  \"Rooms\";");

            context.Rooms.Add(new Room() { Id = 1, Number = "101A", FloorId = 0, BuildingId = "A", Type = RoomType.AppointmentRoom, Description = "neki opis", X = 10, Y = 10, Width = 380, Height = 250 });
            context.Rooms.Add(new Room() { Id = 2, Number = "102A", FloorId = 0, BuildingId = "A", Type = RoomType.AppointmentRoom, Description = "neki opis1", X = 10, Y = 270, Width = 170, Height = 250 });*/
            context.SaveChanges();
         }

    }
}
