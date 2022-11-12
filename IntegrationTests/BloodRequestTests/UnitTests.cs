using IntegrationLibrary.Core.Enums;
using IntegrationLibrary.Features.BloodRequests.DTO;
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
        public void Get_Create_Blood_Request()
        {
            List<BloodRequest> data = GetBloodRequestData();
            BloodRequestService service = new(CreateBloodRequestRepository(data));

            BloodRequestDTO ret = new() { BloodType = "AB_MINUS", QuantityInLiters = 5, ReasonForRequest = "treba 4", FinalDate = new System.DateTime(), DoctorId = 3 };
            service.Create(ret);

            BloodRequest expected = new() { Id = 4, BloodType = BloodType.AB_MINUS, QuantityInLiters = 5, ReasonForRequest = "treba 4", FinalDate = new System.DateTime(), DoctorId = 3 };

            Assert.Equal(data[3], expected);
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
                new BloodRequest() { Id = 1, BloodType = BloodType.A_PLUS, QuantityInLiters = 1, ReasonForRequest = "treba 1", FinalDate = new System.DateTime(), DoctorId = 1 },
                new BloodRequest() { Id = 2, BloodType = BloodType.B_PLUS, QuantityInLiters = 4, ReasonForRequest = "treba 2", FinalDate = new System.DateTime(), DoctorId = 1 },
                new BloodRequest() { Id = 3, BloodType = BloodType.O_MINUS, QuantityInLiters = 9, ReasonForRequest = "treba 3", FinalDate = new System.DateTime(), DoctorId = 2 }
            };
        }

        #endregion
    }
}
