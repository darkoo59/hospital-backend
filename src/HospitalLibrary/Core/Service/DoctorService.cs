using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System.Collections.Generic;
using System.Linq;
using System;


namespace HospitalLibrary.Core.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        Doctor doctor = new Doctor();

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _doctorRepository.GetAll();
        }

        public Doctor GetById(int id)
        {
            return _doctorRepository.GetById(id);
        }
        public IEnumerable<Doctor> GetAllBySpecialization(int specialization)
        {
            return _doctorRepository.GetAllDoctorsBySpecialization(specialization);
        }
    }
}
