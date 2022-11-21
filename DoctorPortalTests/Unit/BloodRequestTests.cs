using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Service;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace HospitalTests.Unit
{
    public class BloodRequestTests
    {
        [Fact]
        public void Get_all_blood_requests()
        {
            List<BloodRequest> requests = GetRequests();
            BloodRequestService service = new(CreateBloodRequestRepository(requests));

            IEnumerable<BloodRequest> ret = service.GetAll();

            Assert.Equal(ret, requests);
        }

        [Fact]
        public void Get_blood_request_by_id()
        {
            List<BloodRequest> requests = GetRequests();
            BloodRequestService service = new(CreateBloodRequestRepository(requests));

            BloodRequest bloodRequest = service.GetById(1);

            Assert.Equal(bloodRequest, requests[0]);
        }


        #region private

        private static IBloodRequestRepository CreateBloodRequestRepository(List<BloodRequest> requests)
        {
            var stubRepo = new Mock<IBloodRequestRepository>();
            stubRepo.Setup(m => m.GetAll()).Returns(requests);
            stubRepo.Setup(m => m.GetById(1)).Returns(requests[0]);

            return stubRepo.Object;
        }

        private static List<BloodRequest> GetRequests()
        {
            return new()
            {
                new BloodRequest() { BloodRequestId = 1, BloodType = BloodType.AB_MINUS, QuantityInLiters = 2.5, ReasonForRequest = "Heart surgery", FinalDate = new System.DateTime(2022, 12, 13), DoctorId = 1 },
                new BloodRequest() { BloodRequestId = 2, BloodType = BloodType.A_PLUS, QuantityInLiters = 3, ReasonForRequest = "Heart surgery", FinalDate = new System.DateTime(2022, 11, 28), DoctorId = 1 },
                new BloodRequest() { BloodRequestId = 3, BloodType = BloodType.O_MINUS, QuantityInLiters = 3.5, ReasonForRequest = "Heart surgery", FinalDate = new System.DateTime(2022, 12, 6), DoctorId = 1 }
            };
        }

        #endregion
    }
}

