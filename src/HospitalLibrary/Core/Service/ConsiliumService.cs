using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.Core.Service
{
    public class ConsiliumService : IConsiliumService
    {
        private readonly IConsiliumRepository _consiliumRepository;
        private readonly IPhysicianScheduleRepository _physicianScheduleRepository;
        private readonly IDoctorRepository _doctorRepository;
        List<List<int>> requiredDoctorsIdList = new List<List<int>>();
        private IConsiliumRepository consiliumRepository;

        public ConsiliumService(IConsiliumRepository consiliumRepository, IDoctorRepository doctorRepository, IPhysicianScheduleRepository physicianScheduleRepository)
        {
            _consiliumRepository = consiliumRepository;
            _doctorRepository = doctorRepository;
            _physicianScheduleRepository = physicianScheduleRepository;          
        }

        public ConsiliumService(IConsiliumRepository consiliumRepository,IDoctorRepository doctorRepository, PhysicianScheduleRepository physicianScheduleRepository)
        {
            _consiliumRepository = consiliumRepository;
            _doctorRepository = doctorRepository;
            _physicianScheduleRepository = physicianScheduleRepository;
        }

        public ConsiliumService(IConsiliumRepository consiliumRepository)
        {
            _consiliumRepository = consiliumRepository;
        }

        public void Create(Consilium consilium)
        {
            _consiliumRepository.Create(consilium);
        }

        public void AddDoctorIdToList(int DoctorId, List<int> DoctorIds)
        {
            DoctorIds.Add(DoctorId);
        }

        public void AddSpecializationIdToList(int SpecializationId, List<int> SpecializationIds)
        {
            SpecializationIds.Add(SpecializationId);
        }

        public bool IsDoctorsAvailableOnConsiliumDate(List<Doctor> doctors, DateTime dateTime)
        {
            int counter = 0;
            Appointment appointment = new Appointment();
            appointment.Start = dateTime;

            foreach (Doctor doctor in doctors)
            {
                PhysicianSchedule physicianSchedule = new PhysicianSchedule();

                physicianSchedule = _physicianScheduleRepository.Get(doctor.DoctorId);

                if (physicianSchedule.IsAppointmentAvailable(appointment) == true)
                {
                    counter++;
                }
            }

            if (counter == doctors.Count)
            {
                return true;
            }
            return false;
        }

        public void CreateConsiliumWithDoctors(Consilium consilium, List<int> DoctorIds)
        {
            List<Doctor> doctors = _doctorRepository.GetAll().ToList();
            List<Doctor> requiredDoctors = new List<Doctor>();
            Appointment appointment = new Appointment();
            consilium.StartTime = new DateTime(consilium.DateRange.Start.Year, consilium.DateRange.Start.Month, consilium.DateRange.Start.Day,10, 0, 0);
            appointment.Start = consilium.StartTime;

            foreach (int doctorId in DoctorIds)
            {
                foreach (Doctor d in doctors)
                {
                    if (d.DoctorId == doctorId)
                    {
                        requiredDoctors.Add(d);
                    }
                }
            }

            ifPetlja:
            {
                if (appointment.Start.Hour >= 10 && appointment.Start.Hour <= 20)
                {
                    if (IsDoctorsAvailableOnConsiliumDate(requiredDoctors, appointment.Start) == true)
                    {
                        consilium.StartTime = new DateTime(appointment.Start.Year,appointment.Start.Month,appointment.Start.Day,appointment.Start.Hour,appointment.Start.Minute,appointment.Start.Second);
                        consilium.RoomId = requiredDoctors[0].RoomId;

                        _consiliumRepository.Create(consilium);
                        return;
                    }
                    else
                    {
                        goto ifPetlja1;
                    }
                }
            }
            ifPetlja1:
                appointment.Start = appointment.Start.AddMinutes(30);
                goto ifPetlja;
        }

        public void CreateConsiliumWithSpecializations(Consilium consilium, List<int> SpecializationIds)
        {
            List<Doctor> doctors = _doctorRepository.GetAll().ToList();
            List<Doctor> potentialDoctors = new List<Doctor>();
            List<int> freeDoctorsId = new List<int>();
            List<int> freeDoctorsSpecializationId = new List<int>();
            Appointment appointment = new Appointment();
            consilium.StartTime = new DateTime(consilium.DateRange.Start.Year, consilium.DateRange.Start.Month, consilium.DateRange.Start.Day,10, 0, 0);
            appointment.Start = consilium.StartTime;
            int counter = 0;

            foreach (int specializationId in SpecializationIds)
            {
                foreach (Doctor d in doctors)
                {
                    if (d.SpecializationId == specializationId)
                    {
                        potentialDoctors.Add(d);
                    }
                }
            }
            ifPetlja:

            if (appointment.Start.Hour >= 10 && appointment.Start.Hour <= 20) 
            {
                foreach (Doctor doctor in potentialDoctors)
                {
                    PhysicianSchedule physicianSchedule = new PhysicianSchedule();
                    physicianSchedule = _physicianScheduleRepository.Get(doctor.DoctorId);
                    counter = counter + 1;

                    if (physicianSchedule.IsAppointmentAvailable(appointment) == true)
                    {
                        freeDoctorsId.Add(doctor.DoctorId);
                        freeDoctorsSpecializationId.Add(doctor.SpecializationId);
                    }

                    List<int> common = freeDoctorsSpecializationId.Intersect(SpecializationIds).ToList();

                    if (freeDoctorsId.Count == potentialDoctors.Count() && common.SequenceEqual(SpecializationIds))
                    {
                        consilium.DoctorIds = freeDoctorsId;
                        consilium.RoomId = doctor.RoomId;

                        consilium.StartTime = appointment.Start;
                        _consiliumRepository.Create(consilium);
                        return;
                    }
                    if(counter == potentialDoctors.Count())
                    {
                        appointment.Start = appointment.Start.AddMinutes(30);
                        freeDoctorsId.Clear();
                        freeDoctorsSpecializationId.Clear();
                        counter = 0;
                        goto ifPetlja;
                    }
                }
                appointment.Start = appointment.Start.AddMinutes(30);
                goto ifPetlja;
            } 
        }

        public IEnumerable<Consilium> GetAll()
        {
            return _consiliumRepository.GetAll();
        }

        public IEnumerable<Consilium> GetAllConsiliumsOfDoctor(int id)
        {
            List<Consilium> consiliums = _consiliumRepository.GetAll().ToList();

            List<Consilium> doctorsConsilium = new List<Consilium>();
            foreach(Consilium c in consiliums)
            {
                List<int> doctors = c.DoctorIds;
                foreach (int doctor in doctors)
                {
                    if(doctor == id)
                    {
                        doctorsConsilium.Add(c);
                        break;
                    }
                }
            }
            return doctorsConsilium;

        }
    }
}
