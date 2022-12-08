using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class ConsiliumService : IConsiliumService
    {
        private readonly IConsiliumRepository _consiliumRepository;
        private readonly IPhysicianScheduleRepository _physicianScheduleRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPhysicianScheduleService _physicianScheduleService;

        public ConsiliumService(IConsiliumRepository consiliumRepository, IDoctorRepository doctorRepository, IPhysicianScheduleRepository physicianScheduleRepository)
        {
            _consiliumRepository = consiliumRepository;
            _doctorRepository = doctorRepository;
            _physicianScheduleRepository = physicianScheduleRepository;
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

        public void CreateConsiliumWithSpecializations(Consilium consilium, List<int> SpecializationIds)
        {

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
            consilium.StartTime = new DateTime(consilium.StartTime.Year, consilium.StartTime.Month, consilium.StartTime.Day, consilium.StartTime.Hour, 0, 0);
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
                appointment.Start = appointment.Start.AddHours(1);
                goto ifPetlja;
        }
    
    
    
    }
}