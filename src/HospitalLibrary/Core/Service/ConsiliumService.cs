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
        private readonly ISpecializationRepository _specializationRepository;
        List<List<int>> requiredDoctorsIdList = new List<List<int>>();


        public ConsiliumService(IConsiliumRepository consiliumRepository, IDoctorRepository doctorRepository, IPhysicianScheduleRepository physicianScheduleRepository,ISpecializationRepository specializationRepository)
        {
            _consiliumRepository = consiliumRepository;
            _doctorRepository = doctorRepository;
            _physicianScheduleRepository = physicianScheduleRepository;
            _specializationRepository = specializationRepository;
            
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
            consilium.StartTime = new DateTime(consilium.StartTime.Year, consilium.StartTime.Month, consilium.StartTime.Day,10, 0, 0);
            appointment.Start = consilium.StartTime;
            int counter = 0;

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
                if (appointment.Start.Hour > 10 && appointment.Start.Hour < 20)
                {
                    if (IsDoctorsAvailableOnConsiliumDate(requiredDoctors, appointment.Start) == true)
                    {
                        consilium.StartTime = new DateTime(appointment.Start.Year,appointment.Start.Month,appointment.Start.Day,appointment.Start.Hour,appointment.Start.Minute,appointment.Start.Second);
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
            List<Doctor> requiredDoctors = new List<Doctor>();
            List<int> freeRequiredDoctorsId = new List<int>();
            Appointment appointment = new Appointment();
            consilium.StartTime = new DateTime(consilium.StartTime.Year, consilium.StartTime.Month, consilium.StartTime.Day,10, 0, 0);
            appointment.Start = consilium.StartTime;
            List<int> NumberOfFreeDoctorsByTerm = new List<int>();
            int counter = 0;

            foreach (int specializationId in SpecializationIds)
            {
                foreach (Doctor d in doctors)
                {
                    if (d.SpecializationId == specializationId)
                    {
                        requiredDoctors.Add(d);
                    }
                }
            }

            ifPetlja:

            if (appointment.Start.Hour >= 10 && appointment.Start.Hour <= 20) 
            {
                foreach (Doctor doctor in requiredDoctors)
                {
                    PhysicianSchedule physicianSchedule = new PhysicianSchedule();
                    physicianSchedule = _physicianScheduleRepository.Get(doctor.DoctorId);

                    if (physicianSchedule.IsAppointmentAvailable(appointment) == true)
                    {
                        counter++;
                        freeRequiredDoctorsId.Add(doctor.DoctorId);
                        if(freeRequiredDoctorsId.Count == requiredDoctors.Count)
                        {
                            consilium.DoctorIds = freeRequiredDoctorsId;
                            return;
                        }
                    }
                }

                //ako ne udje nijednom u ovaj gore if a dodje do 22 smanjujem za 1 pa proveravam
                NumberOfFreeDoctorsByTerm.Add(counter);
                counter = 0;
                appointment.Start = appointment.Start.AddMinutes(30);
                requiredDoctorsIdList.Add(freeRequiredDoctorsId);
                freeRequiredDoctorsId.Clear();
            } 
        }
    }
}
