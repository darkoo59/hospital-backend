using HospitalAPI;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
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
            return "Host=localhost;Database=HospitalTestDb;Username=postgres;Password=marko;";
        }

        private static void InitializeDatabase(HospitalDbContext context)
        {
            context.Database.EnsureCreated();

            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"BloodRequests\";");
            //context.BloodRequests.Add(new BloodRequest() { BloodRequestId = 1, BloodType = BloodType.AB_MINUS, QuantityInLiters = 2.5, ReasonForRequest = "Heart surgery", FinalDate = new System.DateTime(2022, 12, 13), DoctorId = 1 });
            //context.BloodRequests.Add(new BloodRequest() { BloodRequestId = 2, BloodType = BloodType.A_PLUS, QuantityInLiters = 3, ReasonForRequest = "Heart surgery", FinalDate = new System.DateTime(2022, 11, 28), DoctorId = 1 });
            //context.BloodRequests.Add(new BloodRequest() { BloodRequestId = 3, BloodType = BloodType.O_MINUS, QuantityInLiters = 3.5, ReasonForRequest = "Heart surgery", FinalDate = new System.DateTime(2022, 12, 6), DoctorId = 1 });
            
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"VacationRequests\";");
            context.VacationRequests.Add(new VacationRequest() { VacationRequestId = 1, DoctorId = 1, StartDate = DateTime.Now.AddDays(5),EndDate = DateTime.Now.AddDays(10), IsApproved = true , Urgency = "NoUrgent" });

            context.SaveChanges();
        }
    }
}
