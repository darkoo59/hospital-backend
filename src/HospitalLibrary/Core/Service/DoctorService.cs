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

        private readonly IWorkTimeRepository _workTimeRepository;
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

        public Doctor GetDoctorFromWorkTime(int id)
        {
            List<WorkTime> workTimes = _workTimeRepository.GetAll().ToList();
            foreach(WorkTime workTime in workTimes)
            {
                if (workTime.DoctorId.Equals(id))
                {
                    Doctor doctor = _doctorRepository.GetById(id);
                }
            }
            return doctor;
        }
    }
}
