using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _doctorRepository.GetAll();
        }
    }
}
