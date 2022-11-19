using HospitalLibrary.Core.Model;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Repository
{
    public interface IDoctorRepository
    {
        Doctor GetById(int id);
        IEnumerable<Doctor> GetAll();
    }
}
