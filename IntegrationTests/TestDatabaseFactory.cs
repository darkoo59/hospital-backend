using IntegrationAPI;
using IntegrationLibrary.Features.Blood.Enums;
using IntegrationLibrary.Features.BloodBankNews.Enums;
using IntegrationLibrary.Features.BloodBankNews.Model;
using IntegrationLibrary.Features.BloodRequests.Enums;
using IntegrationLibrary.Features.BloodRequests.Model;
using IntegrationLibrary.Features.EquipmentTenders.Domain;
using IntegrationLibrary.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using IntegrationAPI.Authorization;

    namespace IntegrationTests
{
    public class TestDatabaseFactory<TStartup> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                using var scope = BuildServiceProvider(services).CreateScope();
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<IntegrationDbContext>();

                InitializeDatabase(db);
            });
        }

        private static ServiceProvider BuildServiceProvider(IServiceCollection services)
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<IntegrationDbContext>));
            services.Remove(descriptor);

            services.AddDbContext<IntegrationDbContext>(opt => opt.UseNpgsql(CreateConnectionStringForTest()));
            return services.BuildServiceProvider();
        }

        private static string CreateConnectionStringForTest()
        {
            return "Host=localhost;Database=IntegrationTestDb;Username=postgres;Password=password;";
        }

        private static void InitializeDatabase(IntegrationDbContext context)
        {
            AuthorizationUtil.AUTHORIZATION = AuthorizationUtil.DISABLED;
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"BankNews\";");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"BloodRequests\";");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"ReportConfigurations\";");

            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"EquipmentTenders\" CASCADE;");

            context.BankNews.Add(new BankNews() { Id = 1, Title = "vijest 1", Content = "sadrzaj vijesti 1", State = NewsState.NEW });
            context.BankNews.Add(new BankNews() { Id = 2, Title = "vijest 2", Content = "sadrzaj vijesti 2", State = NewsState.DECLINED });
            context.BankNews.Add(new BankNews() { Id = 3, Title = "vijest 3", Content = "sadrzaj vijesti 3", State = NewsState.APPROVED });

            context.BloodRequests.Add(new BloodRequest() { Id = 1, BloodType = BloodType.A_PLUS, QuantityInLiters = 1, ReasonForRequest = "treba 1", FinalDate = new System.DateTime(), DoctorId = 1, State = BloodRequestState.NEW });
            context.BloodRequests.Add(new BloodRequest() { Id = 2, BloodType = BloodType.B_PLUS, QuantityInLiters = 4, ReasonForRequest = "treba 2", FinalDate = new System.DateTime(), DoctorId = 1, State = BloodRequestState.APPROVED });
            context.BloodRequests.Add(new BloodRequest() { Id = 3, BloodType = BloodType.O_MINUS, QuantityInLiters = 9, ReasonForRequest = "treba 3", FinalDate = new System.DateTime(), DoctorId = 2, State = BloodRequestState.DECLINED });
            context.BloodRequests.Add(new BloodRequest() { Id = 4, BloodType = BloodType.O_MINUS, QuantityInLiters = 12, ReasonForRequest = "treba 4", FinalDate = new System.DateTime(), DoctorId = 3, State = BloodRequestState.UPDATE });
            context.BloodRequests.Add(new BloodRequest() { Id = 5, BloodType = BloodType.AB_MINUS, QuantityInLiters = 6, ReasonForRequest = "treba 5", FinalDate = new System.DateTime(), DoctorId = 2, State = BloodRequestState.NEW });
            context.BloodRequests.Add(new BloodRequest() { Id = 6, BloodType = BloodType.O_PLUS, QuantityInLiters = 12, ReasonForRequest = "treba 6", FinalDate = new System.DateTime(), DoctorId = 1, State = BloodRequestState.NEW});
            context.BloodRequests.Add(new BloodRequest() { Id = 7, BloodType = BloodType.O_MINUS, QuantityInLiters = 11, ReasonForRequest = "treba 7", FinalDate = new System.DateTime(), DoctorId = 3, State = BloodRequestState.NEW});

            context.EquipmentTenders.Add(new EquipmentTender(1, "Tender 1", DateTime.Now.AddDays(15), ""));
            context.EquipmentTenders.Add(new EquipmentTender(2, "Tender 2", DateTime.Now.AddDays(15), ""));
            context.EquipmentTenders.Add(new EquipmentTender(3, "Tender 3", DateTime.Now.AddDays(15), ""));

            context.SaveChanges();
        }
    }

}
