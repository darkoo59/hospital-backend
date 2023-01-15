using HospitalLibrary.Core.Model;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Service
{
    public interface IDoctorService
    {
        IEnumerable<Doctor> GetAll();
        Doctor GetById(int id);
        IEnumerable<Doctor> GetAllBySpecialization(int specializationId);
    }
}
