using HospitalLibrary.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalLibrary.Registration.Service
{
    public interface IPatientService
    {

        Task<bool> Register(Patient patient);
        IEnumerable<Patient> GetAll();
        Patient GetById(int id);
        void Delete(Patient patient);
        void ActivateAccount(Patient patient);
    }
}
