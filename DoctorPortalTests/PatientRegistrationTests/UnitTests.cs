using HospitalLibrary.Core.Model;
using HospitalLibrary.Registration.Repository;
using HospitalLibrary.Registration.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalTests.PatientRegistrationTests
{
    public class UnitTests
    {
        [Fact]
        public void Get_All_Patients()
        {
            List<Patient> data = GetPatientsData();

            PatientService service = new(CreatePatientsRepository(data), null, null, null);

            IEnumerable<Patient> ret = service.GetAll();

            Assert.Equal(ret, data);
        }

        [Fact]
        public void Activate_account()
        {
            List<Patient> data = GetPatientsData();
            PatientService service = new(CreatePatientsRepository(data), null, null, null);

            service.ActivateAccount(data[1]);

            Assert.True(data[1].IsAccountActivated);
        }

        [Fact]
        public void Get_Patient_By_Id()
        {
            List<Patient> data = GetPatientsData();
            PatientService service = new(CreatePatientsRepository(data), null, null, null);

            Patient pat = service.GetById(1);

            Assert.Equal(pat, data[0]);
        }





        #region private

        private static IPatientRepository CreatePatientsRepository(List<Patient> data)
        {
            Mock<IPatientRepository> studRepo = new();
            studRepo.Setup(m => m.GetAll()).Returns(data);
            studRepo.Setup(m => m.GetById(1)).Returns(data[0]);
            studRepo.Setup(m => m.GetById(2)).Returns(data[1]);
            studRepo.Setup(m => m.GetById(3)).Returns(data[2]);

            return studRepo.Object;
        }

        private List<Patient> GetPatientsData()
        {
            return new()
            {
                new Patient() {IsAccountActivated = false, Name = "Pera", PatientId = 1, Surname = "Peric"},
                new Patient() { IsAccountActivated = false, Name = "Pera2", PatientId = 2, Surname = "Peric2"},
                new Patient() { IsAccountActivated = false, Name = "Pera3", PatientId = 3, Surname = "Peric3" }
            };
        }

        #endregion
    }
}
