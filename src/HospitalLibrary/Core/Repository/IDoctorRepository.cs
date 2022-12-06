using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HospitalLibrary.Core.Repository
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetAll();
        public Doctor GetById(int id);
        List<Doctor> GetAllDoctorsBySpecialization(int specialization);
    }
}
