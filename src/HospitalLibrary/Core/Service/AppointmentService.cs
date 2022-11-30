using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.Core.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IVacationRepository _vacationRepository;
        private readonly IWorkTimeRepository _workTimeRepository;
        private readonly IDoctorService _doctorService;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public AppointmentService(IDoctorService doctorService,IDoctorRepository doctorRepository,IWorkTimeRepository workTimeRepository, IAppointmentRepository appointmentRepositroy)
        {
            _doctorService = doctorService;
            _workTimeRepository = workTimeRepository;
            _appointmentRepository = appointmentRepositroy;
            _doctorRepository = doctorRepository;
        }

        public AppointmentService(IDoctorRepository doctorRepository, IAppointmentRepository appointmentRepository, IVacationRepository vacationRepository, IWorkTimeRepository workTimeRepository, IDoctorService doctorService)
        {
            _appointmentRepository = appointmentRepository;
            _vacationRepository = vacationRepository;
            _workTimeRepository = workTimeRepository;
            _doctorService = doctorService;
            _doctorRepository = doctorRepository;
        }

        public void Create(Appointment appointment)
        {
            if (IsAppointmentValid(appointment))
            {
                _appointmentRepository.Create(appointment);
            }
        }

        public void Update(Appointment appointment)
        {
            if (IsAppointmentValid(appointment))
            {
                _appointmentRepository.Update(appointment);
            }
        }

        private bool IsAppointmentValid(Appointment appointment)
        {
            return IsAppointmentAvailable(appointment) && IsDoctorOnVacation(appointment) && IsDoctorAvailable(appointment) && !IsWeekend(appointment.Start);
        }

        public void Delete(Appointment appointment)
        {
            _appointmentRepository.Delete(appointment);
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _appointmentRepository.GetAll();
        }

        public Appointment GetById(int id)
        {
            return _appointmentRepository.GetById(id);
        }

        private bool IsAppointmentAvailable(Appointment appointment)
        {
            bool isAvailable = true;
            foreach (var a in _appointmentRepository.GetAll().ToList())
            {
                if (a.Start == appointment.Start)
                {
                    isAvailable = false;
                    break;
                }
            }
            return isAvailable;
        }

        public bool IsDoctorOnVacation(Appointment appointment)
        {
            bool isAvailable = true;
            foreach (var vacation in _vacationRepository.GetAll().ToList())
            {
                if (appointment.Start >= vacation.StartDate && appointment.Start <= vacation.EndDate)
                {
                    isAvailable = false;
                    break;
                }
            }
            return isAvailable;
        }

        private bool IsDoctorAvailable(Appointment appointment)
        {
            bool isAvailable = false;
            foreach (var workTime in _workTimeRepository.GetAll().ToList())
            {
                if (IsDoctorWorking(appointment, workTime))
                {
                    isAvailable = true;
                    break;
                }
            }
            return isAvailable;
        }

        private static bool IsDoctorWorking(Appointment appointment, WorkTime workTime)
        {  
            return appointment.Start >= workTime.DateRange.Start && appointment.Start <= workTime.DateRange.End && appointment.Start.TimeOfDay >= workTime.StartTime && appointment.Start.TimeOfDay <= workTime.EndTime;
        }


        private static bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek.Equals(DayOfWeek.Saturday) || date.DayOfWeek.Equals(DayOfWeek.Sunday);
        }

        public List<Appointment> GetDoctorAppointments(int DoctorId)
        {
            List<Appointment> doctorAppointments = new List<Appointment>();
            List<Appointment> appointments = _appointmentRepository.GetAll().ToList();

            foreach (var appointment in appointments)
            {
                if (appointment.DoctorId == DoctorId)
                {
                    doctorAppointments.Add(appointment);
                }
            }
            return doctorAppointments;
        }
        //Start functions in user story Create VacationRequest
        public List<Appointment> GetAppointmentInVacationDateRange(int? doctorId, DateTime startDate, DateTime endDate)
        {
            List<Appointment> doctorAppointments = GetDoctorAppointments((int)doctorId);
            List<Appointment> doctorAppointmentsInVacationDate = new List<Appointment>();

            foreach (Appointment appointment in doctorAppointments)
            {
                if (appointment.Start > startDate && appointment.Start < endDate)
                {
                    doctorAppointmentsInVacationDate.Add(appointment);
                }
            }
            return doctorAppointmentsInVacationDate;
        }

        public bool IsDoctorScheduledInVacationDateRange(int doctorId,DateTime dateStart,DateTime dateEnd)
        {
            List<Appointment> appointments = GetDoctorAppointments((int)doctorId);

            foreach(Appointment appointment in appointments)
            {
                if(appointment.Start >= dateStart && appointment.Start <= dateEnd)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsDoctorScheduled(Appointment appointment, int doctorId)
        {
            List<Appointment> appointments = GetDoctorAppointments(doctorId);

            foreach (Appointment app in appointments)
            {
                if (app.Start == appointment.Start)
                {
                    return true;
                }
            }
            return false;
        }

        public void MakeTransfer(Appointment appointment, int doctorId)
        {
            appointment.DoctorId = doctorId;
            _appointmentRepository.Update(appointment);
        }

        public bool ChangeAppointmentDoctor(List<Appointment> appointmentsInVacationDate)
        {
            throw new NotImplementedException();
        }

        //public bool ChangeAppointmentDoctor(List<Appointment> appointmentsInVacationDate)
        //{
        //    WorkTime doctorWorkTime = new WorkTime();
        //    List<Doctor> doctors = _doctorService.GetAll().ToList();
        //    List<WorkTime> workTimes = _workTimeRepository.GetAll().ToList();
        //    int counter = 0;

        //    foreach (Doctor doctor in doctors)
        //    {
        //        foreach(WorkTime workTime in workTimes)
        //        {
        //            if (workTime.DoctorId.Equals(doctor.DoctorId))
        //            {
        //                doctorWorkTime = workTime;
        //            }
        //        }

        //        foreach (Appointment appointment in appointmentsInVacationDate)
        //        {

        //            Doctor originalAppointmentDoctor = _doctorRepository.GetById((int)appointment.DoctorId);

        //            if (IsDoctorScheduled(appointment, doctor.DoctorId) == false && originalAppointmentDoctor.SpecializationId == doctor.SpecializationId && IsDoctorWorking(appointment,doctorWorkTime) == true)
        //            {
        //                counter++;
        //            }
        //            if (counter == appointmentsInVacationDate.Count())
        //            {
        //                foreach (Appointment app in appointmentsInVacationDate)
        //                {
        //                    MakeTransfer(app, doctor.DoctorId);
        //                    counter = counter - 1;
        //                    if (counter == 0)
        //                    {
        //                        return true;
        //                    }
        //                }

        //            }
        //        }
        //    }
        //    return false;
        //} 
    }
}

