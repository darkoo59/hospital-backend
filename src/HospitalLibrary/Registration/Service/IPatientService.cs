using HospitalLibrary.Core.Model;
using HospitalLibrary.SharedModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalLibrary.Registration.Service
{
    public interface IPatientService
    {

        Task<bool> Register(User user, Patient patient, MedicalRecord medicalRecord);
        IEnumerable<Patient> GetAll();
        Patient GetById(int id);
        void Delete(Patient patient);
        void ActivateAccount(Patient patient);
    }
}
