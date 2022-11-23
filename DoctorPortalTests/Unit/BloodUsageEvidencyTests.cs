using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalTests.Unit
{
    public class BloodUsageEvidencyTests
    {


        [Fact]
        public void Get_all_blood_usage_evidency()
        {
            List<BloodUsageEvidency> requests = GetUsageEvidency();
            BloodUsageEvidencyService service = new(CreateBloodUsageEvidencyRepository(requests));

            IEnumerable<BloodUsageEvidency> ret = service.GetAll();

            Xunit.Assert.Equal(ret, requests);
        }


        [Fact]
        public void Get_blood_usage_evidency_by_id()
        {
            List<BloodUsageEvidency> requests = GetUsageEvidency();
            BloodUsageEvidencyService service = new(CreateBloodUsageEvidencyRepository(requests));

            BloodUsageEvidency bloodUsageEvidency = service.GetById(1);

            Xunit.Assert.Equal(bloodUsageEvidency, requests[0]);
        }



        #region private

        private static IBloodUsageEvidencyRepository CreateBloodUsageEvidencyRepository(List<BloodUsageEvidency> usageEvidency)
        {
            var stubRepo = new Mock<IBloodUsageEvidencyRepository>();
            stubRepo.Setup(m => m.GetAll()).Returns(usageEvidency);
            stubRepo.Setup(m => m.GetById(1)).Returns(usageEvidency[0]);

            return stubRepo.Object;
        }

        private static List<BloodUsageEvidency> GetUsageEvidency()
        {
            return new()
            {
               new BloodUsageEvidency() { BloodUsageEvidencyId = 1, BloodType = BloodType.A_PLUS, QuantityUsedInMililiters = 200, DateOfUsage = new System.DateTime(2022, 12, 13), ReasonForUsage = "Hearth surgery", DoctorId = 1 }

            };
        }

        #endregion
        
    }
}
