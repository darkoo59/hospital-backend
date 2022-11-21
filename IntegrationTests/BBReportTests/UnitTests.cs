using IntegrationLibrary.Core.Enums;
using IntegrationLibrary.Features.BloodBankReports.Model;
using IntegrationLibrary.Features.BloodBankReports.Service;
using IntegrationLibrary.HospitalRepository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests.BBReportTests
{
    public class UnitTests
    {
       [Fact]
       public void Get_All_Blood_Usage_Evidencies()
       {
            List<BloodUsageEvidency> data = GetBloodUsageEvidencyData();
            BBReportsService service = new(CreateHospitalRepository(data));

            List<BloodUsageEvidency> ret = service.GetEvidencies(1000);

            Assert.Equal(ret, data);
       }

        [Fact]
        public void Generate_Report()
        {
            List<BloodUsageEvidency> data = GetBloodUsageEvidencyData();
            BBReportsService service = new(CreateHospitalRepository(data));

            String filePath = service.GenerateReport(data, 15);
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

        private static IHospitalRepository CreateHospitalRepository(List<BloodUsageEvidency> data)
        {
            Mock<IHospitalRepository> studRepo = new();

            studRepo.Setup(m => m.GetAllEvidency()).Returns(Task.FromResult(data));

            return studRepo.Object;
        }
    }
}
