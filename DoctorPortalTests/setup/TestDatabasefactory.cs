using HospitalAPI;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
            return "Host=localhost;Database=HospitalTestDb;Username=postgres;Password=andjela;";
        }

        private static void InitializeDatabase(HospitalDbContext context)
        {
            context.Database.EnsureCreated();

            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"BloodRequests\";");
            //context.BloodRequests.Add(new BloodRequest() { BloodRequestId = 1, BloodType = BloodType.AB_MINUS, QuantityInLiters = 2.5, ReasonForRequest = "Heart surgery", FinalDate = new System.DateTime(2022, 12, 13), DoctorId = 1 });
            //context.BloodRequests.Add(new BloodRequest() { BloodRequestId = 2, BloodType = BloodType.A_PLUS, QuantityInLiters = 3, ReasonForRequest = "Heart surgery", FinalDate = new System.DateTime(2022, 11, 28), DoctorId = 1 });
            //context.BloodRequests.Add(new BloodRequest() { BloodRequestId = 3, BloodType = BloodType.O_MINUS, QuantityInLiters = 3.5, ReasonForRequest = "Heart surgery", FinalDate = new System.DateTime(2022, 12, 6), DoctorId = 1 });



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

            context.BloodUsageEvidencies.Add(new BloodUsageEvidency() { BloodUsageEvidencyId = 1, BloodType = BloodType.A_PLUS, QuantityUsedInMililiters = 200, DateOfUsage = new System.DateTime(2022, 12, 13), ReasonForUsage = "Hearth surgery", DoctorId = 1 });

            context.SaveChanges();
         }
    }
}
