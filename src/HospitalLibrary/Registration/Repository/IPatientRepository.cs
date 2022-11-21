using HospitalLibrary.Core.Model;
using System.Collections.Generic;

namespace HospitalLibrary.Registration.Repository
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetAll();
        Patient GetById(int id);
        void Register(Patient patient);
        void Update(Patient patient);
        void Delete(Patient patient);
    }
}
