using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Features.Blood.Enums;
using IntegrationLibrary.Features.BloodRequests.DTO;
using IntegrationLibrary.Features.BloodRequests.Enums;
using IntegrationLibrary.Features.BloodRequests.Model;
using IntegrationLibrary.Features.BloodRequests.Repository;
using IntegrationLibrary.Features.BloodRequests.Service;
using IntegrationLibrary.HospitalService;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests.BloodRequestTests
{
    public class UnitTests
    {

        [Fact]
        public void Get_All_Blood_Requests()
        {
            List<BloodRequest> data = GetBloodRequestData();
            List<Doctor> doctors = GetDoctorData();
            BloodRequestService service = new(CreateBloodRequestRepository(data), CreateHospitalRepository(doctors));

            IEnumerable<BloodRequest> ret = service.GetAll();

            Assert.Equal(ret, data);
        }

        [Fact]
        public void Get_Blood_Request_By_Id()
        {
            List<BloodRequest> data = GetBloodRequestData();
            List<Doctor> doctors = GetDoctorData();
            BloodRequestService service = new(CreateBloodRequestRepository(data), CreateHospitalRepository(doctors));

            BloodRequest ret = service.GetById(2);

            Assert.Equal(ret, data[1]);
        }

        [Fact]
        public async Task<bool> Get_New_Blood_Requests()
        {
            List<BloodRequest> data = GetBloodRequestData();
            List<Doctor> doctors = GetDoctorData();
            BloodRequestService service = new(CreateBloodRequestRepository(data), CreateHospitalRepository(doctors));

            List<BloodRequestDTO> ret = await service.GetAllByState(BloodRequestState.NEW) as List<BloodRequestDTO>;

            Assert.True(ret[0].Equals(new BloodRequestDTO(data[0])));

            return true;
        }

        [Fact]
        public async Task<bool> Get_Approved_Blood_Requests()
        {
            List<BloodRequest> data = GetBloodRequestData();
            List<Doctor> doctors = GetDoctorData();
            BloodRequestService service = new(CreateBloodRequestRepository(data), CreateHospitalRepository(doctors));

            List<BloodRequestDTO> ret = await service.GetAllByState(BloodRequestState.APPROVED) as List<BloodRequestDTO>;

            Assert.True(ret[0].Equals(new BloodRequestDTO(data[1])));

            return true;
        }

        [Fact]
        public async Task<bool> Get_Declined_Blood_Requests()
        {
            List<BloodRequest> data = GetBloodRequestData();
            List<Doctor> doctors = GetDoctorData();
            BloodRequestService service = new(CreateBloodRequestRepository(data), CreateHospitalRepository(doctors));

            List<BloodRequestDTO> ret = await service.GetAllByState(BloodRequestState.DECLINED) as List<BloodRequestDTO>;

            Assert.True(ret[0].Equals(new BloodRequestDTO(data[2])));

            return true;
        }

        [Fact]
        public async Task<bool> Get_Blood_Requests_For_Update()
        {
            List<BloodRequest> data = GetBloodRequestData();
            List<Doctor> doctors = GetDoctorData();
            BloodRequestService service = new(CreateBloodRequestRepository(data), CreateHospitalRepository(doctors));

            List<BloodRequestDTO> ret = await service.GetAllByState(BloodRequestState.UPDATE) as List<BloodRequestDTO>;

            Assert.True(ret[0].Equals(new BloodRequestDTO(data[3])));

            return true;
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

        private static IHospitalService CreateHospitalRepository(IEnumerable<Doctor> data)
        {
            Mock<IHospitalService> studRepo = new();

            studRepo.Setup(m => m.GetAllDoctors()).Returns(Task.FromResult(data));

            return studRepo.Object;
        }

        private static List<BloodRequest> GetBloodRequestData()
        {
            return new()
            {
                new BloodRequest() { Id = 1, BloodType = BloodType.A_PLUS, QuantityInLiters = 1, ReasonForRequest = "treba 1", FinalDate = new System.DateTime(), DoctorId = 1, State = BloodRequestState.NEW },
                new BloodRequest() { Id = 2, BloodType = BloodType.B_PLUS, QuantityInLiters = 4, ReasonForRequest = "treba 2", FinalDate = new System.DateTime(), DoctorId = 1, State = BloodRequestState.APPROVED },
                new BloodRequest() { Id = 3, BloodType = BloodType.O_MINUS, QuantityInLiters = 9, ReasonForRequest = "treba 3", FinalDate = new System.DateTime(), DoctorId = 2, State = BloodRequestState.DECLINED },
                new BloodRequest() { Id = 4, BloodType = BloodType.O_MINUS, QuantityInLiters = 12, ReasonForRequest = "treba 4", FinalDate = new System.DateTime(), DoctorId = 3, State = BloodRequestState.UPDATE }
            };
        }

        private static List<Doctor> GetDoctorData()
        {
            return new() {
                new Doctor() { DoctorId = 1, Name = "Ognjen", Surname = "Nikolic" },
                new Doctor() { DoctorId = 2, Name = "Mika", Surname = "Mikic" },
                new Doctor() { DoctorId = 3, Name = "Aleksa", Surname = "Santic" }
            };
        }

        #endregion
    }
}
