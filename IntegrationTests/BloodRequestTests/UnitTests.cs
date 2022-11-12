using IntegrationLibrary.Core.Enums;
using IntegrationLibrary.Features.BloodRequests.Enums;
using IntegrationLibrary.Features.BloodRequests.Model;
using IntegrationLibrary.Features.BloodRequests.Repository;
using IntegrationLibrary.Features.BloodRequests.Service;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace IntegrationTests.BloodRequestTests
{
    public class UnitTests
    {

        [Fact]
        public void Get_All_Blood_Requests()
        {
            List<BloodRequest> data = GetBloodRequestData();
            BloodRequestService service = new(CreateBloodRequestRepository(data));

            IEnumerable<BloodRequest> ret = service.GetAll();

            Assert.Equal(ret, data);
        }

        [Fact]
        public void Get_Blood_Request_By_Id()
        {
            List<BloodRequest> data = GetBloodRequestData();
            BloodRequestService service = new(CreateBloodRequestRepository(data));

            BloodRequest ret = service.GetById(2);

            Assert.Equal(ret, data[1]);
        }

        [Fact]
        public void Get_Unchecked_Blood_Requests()
        {
            List<BloodRequest> data = GetBloodRequestData();
            BloodRequestService service = new(CreateBloodRequestRepository(data));

            List<BloodRequest> ret = service.GetAllByState(BloodRequestState.UNCHECKED) as List<BloodRequest>;

            Assert.Equal(ret[0], data[0]);
        }

        [Fact]
        public void Get_Approved_Blood_Requests()
        {
            List<BloodRequest> data = GetBloodRequestData();
            BloodRequestService service = new(CreateBloodRequestRepository(data));

            List<BloodRequest> ret = service.GetAllByState(BloodRequestState.APPROVED) as List<BloodRequest>;

            Assert.Equal(ret[0], data[1]);
        }

        [Fact]
        public void Get_Disapproved_Blood_Requests()
        {
            List<BloodRequest> data = GetBloodRequestData();
            BloodRequestService service = new(CreateBloodRequestRepository(data));

            List<BloodRequest> ret = service.GetAllByState(BloodRequestState.DISAPPROVED) as List<BloodRequest>;

            Assert.Equal(ret[0], data[2]);
        }

        [Fact]
        public void Get_Blood_Requests_For_Update()
        {
            List<BloodRequest> data = GetBloodRequestData();
            BloodRequestService service = new(CreateBloodRequestRepository(data));

            List<BloodRequest> ret = service.GetAllByState(BloodRequestState.UPDATE) as List<BloodRequest>;

            Assert.Equal(ret[0], data[3]);
        }

        #region private

        private static IBloodRequestRepository CreateBloodRequestRepository(List<BloodRequest> data)
        {
            Mock<IBloodRequestRepository> studRepo = new();
            studRepo.Setup(m => m.GetAll()).Returns(data);
            studRepo.Setup(m => m.GetById(1)).Returns(data[0]);
            studRepo.Setup(m => m.GetById(2)).Returns(data[1]);
            studRepo.Setup(m => m.GetById(3)).Returns(data[2]);

            return studRepo.Object;
        }

        private static List<BloodRequest> GetBloodRequestData()
        {
            return new()
            {
                new BloodRequest() { Id = 1, BloodType = BloodType.A_PLUS, QuantityInLiters = 1, ReasonForRequest = "treba 1", FinalDate = new System.DateTime(), DoctorId = 1, State = BloodRequestState.UNCHECKED },
                new BloodRequest() { Id = 2, BloodType = BloodType.B_PLUS, QuantityInLiters = 4, ReasonForRequest = "treba 2", FinalDate = new System.DateTime(), DoctorId = 1, State = BloodRequestState.APPROVED },
                new BloodRequest() { Id = 3, BloodType = BloodType.O_MINUS, QuantityInLiters = 9, ReasonForRequest = "treba 3", FinalDate = new System.DateTime(), DoctorId = 2, State = BloodRequestState.DISAPPROVED },
                new BloodRequest() { Id = 4, BloodType = BloodType.O_MINUS, QuantityInLiters = 12, ReasonForRequest = "treba 4", FinalDate = new System.DateTime(), DoctorId = 3, State = BloodRequestState.UPDATE }
            };
        }

        #endregion
    }
}
