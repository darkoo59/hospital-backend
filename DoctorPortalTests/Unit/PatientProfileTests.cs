using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Registration.Repository;
using HospitalLibrary.Registration.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalTests.Unit
{
    public class PatientProfileTests
    {
        //[Fact]
        //public void Get_patient_by_id()
        //{
            //List<Patient> patients = GetPatients();
            //PatientService service = new(CreatePatientRepository(patients), null, null, null);

        //    Patient patient = service.GetById(1);

        //    Assert.Equal(patient, patients[0]);
        //}

        //private static IPatientRepository CreatePatientRepository(List<Patient> patient)
        //{
        //    var stubRepo = new Mock<IPatientRepository>();
        //    stubRepo.Setup(m => m.GetAll()).Returns(patient);
        //    stubRepo.Setup(m => m.GetById(1)).Returns(patient[0]);
        //    stubRepo.Setup(m => m.GetById(2)).Returns(patient[1]);
        //    stubRepo.Setup(m => m.GetById(3)).Returns(patient[2]);
        //    stubRepo.Setup(m => m.GetById(4)).Returns(patient[3]);
        //    stubRepo.Setup(m => m.GetById(5)).Returns(patient[4]);
        //    stubRepo.Setup(m => m.GetById(6)).Returns(patient[5]);
        //    stubRepo.Setup(m => m.GetById(7)).Returns(patient[6]);

        //    return stubRepo.Object;
        //}

        //private static List<Patient> GetPatients()
        //{
        //    return new()
        //    {
        //        new Patient() { PatientId = 1, Name = "Marko", Surname = "Markovic" },
        //        new Patient() { PatientId = 2, Name = "Darko", Surname = "Darkovic" },
        //        new Patient() { PatientId = 3, Name = "Zarko", Surname = "Zarkovic" },
        //        new Patient() { PatientId = 4, Name = "Jarko", Surname = "Jarkovic" },
        //        new Patient() { PatientId = 5, Name = "Borko", Surname = "Borkovic" },
        //        new Patient() { PatientId = 6, Name = "Zvonko", Surname = "Zvonkovic" },
        //        new Patient() { PatientId = 7, Name = "Mirko", Surname = "Mirkovic" }
        //    };
        //}
    }
}
