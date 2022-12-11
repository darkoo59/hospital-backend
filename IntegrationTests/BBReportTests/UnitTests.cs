using IntegrationLibrary.Features.Blood.Enums;
using IntegrationLibrary.Features.BloodBankReports.Model;
using IntegrationLibrary.Features.BloodBankReports.Service;
using IntegrationLibrary.HospitalService;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.Features.BloodBank.Model;
using IntegrationLibrary.Features.BloodBank.Repository;
using IntegrationLibrary.Features.BloodBank.Service;
using Xunit;

namespace IntegrationTests.BBReportTests
{
    public class UnitTests
    {
       [Fact]
       public void Get_All_Blood_Usage_Evidencies()
       {
            List<BloodUsageEvidency> data = GetBloodUsageEvidencyData();
            BBReportsService service = new(CreateHospitalRepository(data), null);

            List<BloodUsageEvidency> ret = service.GetEvidencies(1000);

            Assert.Equal(ret, data);
       }

        [Fact]
        public void Generate_Report()
        {
            List<BloodUsageEvidency> data = GetBloodUsageEvidencyData();
            User user = new User() { Id = 1, AppName = "Test banka", Email = "banka@gmail.com", Password = "12345444", Server = "localhost:4444" };
            BBReportsService service = new(CreateHospitalRepository(data), 
                createUserService(user));

            String filePath = service.GenerateReport(user.Id,data, 15);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
                Assert.True(true);
            }
            else
                Assert.True(false);
        }




        private static List<BloodUsageEvidency> GetBloodUsageEvidencyData()
        {
            return new()
            {
                new BloodUsageEvidency() { BloodUsageEvidencyId = 1, BloodType = BloodType.B_PLUS, QuantityUsedInMililiters = 900, DateOfUsage = new DateTime(2022, 9, 13), DoctorId = 11, ReasonForUsage = "Trebalo 1" },
                new BloodUsageEvidency() { BloodUsageEvidencyId = 2, BloodType = BloodType.A_MINUS, QuantityUsedInMililiters = 1200, DateOfUsage = new DateTime(2022, 10, 24), DoctorId = 12, ReasonForUsage = "Trebalo 2" },
                new BloodUsageEvidency() { BloodUsageEvidencyId = 3, BloodType = BloodType.O_PLUS, QuantityUsedInMililiters = 750, DateOfUsage = new DateTime(2022, 6, 3), DoctorId = 13, ReasonForUsage = "Trebalo 3" }
            };
        }

        private static List<User> GetUsersData()
        {
            return new()
            {
                new User() { Id=1, AppName = "Banka krvi", Email = "banka@gmail.com", Password = "salaposalica", Server = "localhost:6969"}
            };
        }

        private static IHospitalService CreateHospitalRepository(List<BloodUsageEvidency> data)
        {
            Mock<IHospitalService> studRepo = new();

            studRepo.Setup(m => m.GetAllEvidency()).Returns(Task.FromResult(data));

            return studRepo.Object;
        }

        private static IUserRepository CreateUserRepository(List<User> data)
        {
            Mock<IUserRepository> studRepo = new();

            studRepo.Setup(m => m.GetAll()).Returns(data);

            return studRepo.Object;
        }

        private static IUserService createUserService(User user)
        {
            Mock<IUserService> studServ = new();

            studServ.Setup(m => m.GetById(user.Id)).Returns(user);

            return studServ.Object;
        }

    }
}
