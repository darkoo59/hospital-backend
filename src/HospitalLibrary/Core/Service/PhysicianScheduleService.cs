using System;
﻿using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using Org.BouncyCastle.Crypto.Tls;

namespace HospitalLibrary.Core.Service
{
    public class PhysicianScheduleService : IPhysicianScheduleService
    {
        private readonly IPhysicianScheduleRepository _physicianScheduleRepository;
        private readonly IDoctorRepository _doctorRepository;

        public PhysicianScheduleService(IPhysicianScheduleRepository physicianScheduleRepository, IDoctorRepository doctorRepository)
        {
            _physicianScheduleRepository = physicianScheduleRepository;
            _doctorRepository = doctorRepository;
        }
        public void Create(PhysicianSchedule physicianSchedule)
        {
            _physicianScheduleRepository.Create(physicianSchedule);
        }

        public void Delete(PhysicianSchedule physicianSchedule)
        {
            _physicianScheduleRepository.Delete(physicianSchedule);
        }

        public IEnumerable<PhysicianSchedule> GetAll()
        {
            return _physicianScheduleRepository.GetAll();
        }

        public List<Appointment> GetAvailableAppointments(int doctorId, DateTime date)
        {
            return FindFreeAppointments(new DateRange(date, date.AddSeconds(1)), doctorId);
        }

        public PhysicianSchedule GetById(int id)
        {
            return _physicianScheduleRepository.GetById(id);
        }

        public PhysicianSchedule Get(int doctorId)
        {
            foreach (var physicianSchedule in _physicianScheduleRepository.GetAll())
            {
                if (physicianSchedule.DoctorId == doctorId)
                {
                    return physicianSchedule;
                }
            }

            return null;
        }

        public List<Appointment> GetAppointments(int doctorId)
        {
            List<Appointment> appointments = new List<Appointment>();
            foreach (var physicianSchedule in _physicianScheduleRepository.GetAll())
            {
                if (physicianSchedule.DoctorId == doctorId)
                {
                    foreach (var appointment in physicianSchedule.Appointments)
                    {
                        if (!appointment.IsFinished)
                        {
                            appointments.Add(appointment);
                        }
                    }
                }
            }

            return appointments;
        }

        public bool Schedule(int doctorId, Appointment appointment)
        {
            PhysicianSchedule physicianSchedule = _physicianScheduleRepository.Get(doctorId);
            if (physicianSchedule.IsAppointmentValid(appointment))
            {
                physicianSchedule.Appointments.Add(appointment);
                Update(physicianSchedule);
                return true;
            }

            return false;
        }

        public void TransferAppointment(int doctorId, Appointment appointment)
        {
            PhysicianSchedule physicianSchedule = _physicianScheduleRepository.Get(doctorId);
            physicianSchedule.Appointments.Add(appointment);
            _physicianScheduleRepository.Update(physicianSchedule);
        }

        public void Update(PhysicianSchedule physicianSchedule)
        {
            _physicianScheduleRepository.Update(physicianSchedule);
        }
        public List<Appointment> GetRecommendedAppointments(DateRange dateRange, int doctorId, string priority)
        {
            List<Appointment> appointments = FindFreeAppointments(dateRange, doctorId);
            if (appointments.Count != 0)
            {
                return appointments;
            }
            else if (priority.Equals("Date"))
            {
                return GetAppointmentsByDatePriority(dateRange, doctorId);
            }
            else if (priority.Equals("Doctor"))
            {
                return GetAppointmentsByDoctorPriority(dateRange, doctorId);
            }
            return null;
        }

        private List<Appointment> FindFreeAppointments(DateRange dateRange, int doctorId)
        {
            List<Appointment> appointments = new List<Appointment>();
            List<DateRange> dates = AddDoctorsWorkTimes(dateRange, _physicianScheduleRepository.FindByDoctor(doctorId));
            DeleteDoctorsBusyTimes(dates, doctorId);
            foreach (DateRange d in dates)
            {
                Appointment app = new Appointment();
                app.ScheduledDate = d;
                app.DoctorId = 2;
                app.Doctor = _doctorRepository.GetById(2);
                app.PatientId = 1;
                app.IsFinished = false;
                appointments.Add(app);
            }
            return appointments;
        }

        private List<Appointment> GetAppointmentsByDoctorPriority(DateRange dateRange, int doctorId)
        {
            DateRange dateRangeExtended = ExtendDateRange(dateRange);
            List<DateRange> dates = AddDoctorsWorkTimes(dateRangeExtended, _physicianScheduleRepository.FindByDoctor(doctorId));
            List<Appointment> appointments = new List<Appointment>();
            DeleteDoctorsBusyTimes(dates, doctorId);
            foreach (DateRange d in dates)
            {
                Appointment app = new Appointment();
                app.ScheduledDate = d;
                app.DoctorId = doctorId;
                app.Doctor = _doctorRepository.GetById(doctorId);
                app.PatientId = 1;
                appointments.Add(app);
            }
            return appointments;
        }
        private List<Appointment> GetAppointmentsByDatePriority(DateRange dateRange, int doctorId)
        {
            int specialization = _doctorRepository.GetById(doctorId).SpecializationId;
            List<Doctor> doctors = _doctorRepository.GetAllDoctorsBySpecialization(specialization);
            List<Appointment> appointments = new List<Appointment>();
            foreach (Doctor d in doctors)
            {
                List<DateRange> dates = AddDoctorsWorkTimes(dateRange, _physicianScheduleRepository.FindByDoctor(d.DoctorId));
                DeleteDoctorsBusyTimes(dates, doctorId);
                foreach (DateRange date in dates)
                {
                    Appointment app = new Appointment();
                    app.ScheduledDate = date;
                    app.Doctor = d;
                    appointments.Add(app);
                }
            }
            return appointments;
        }
        private List<DateRange> AddDoctorsWorkTimes(DateRange dateRange, PhysicianSchedule physicianSchedule)
        {
            List<DateRange> dates = new List<DateRange>();
            foreach (WorkTime workTime in physicianSchedule.WorkTimes)
            {
                WorkTime workTimeOverlapped = CheckIfDateRangeOverlaps(dateRange, workTime);
                if (workTimeOverlapped != null)
                {
                    foreach(DateRange date in workTimeOverlapped.SeparateDateRange())
                    {
                        dates.Add(date);
                    }
                }
            }
            return dates;
        }
        private void DeleteDoctorsBusyTimes(List<DateRange> dateRanges, int doctorId)
        {
            foreach (Appointment app in GetAppointments(doctorId))
            {
                foreach (DateRange dateRange in dateRanges)
                {
                    if (app.CheckIfDateRangeInAppointment(dateRange))
                    {
                        dateRanges.Remove(dateRange);
                        break;
                    }
                }
            }
        }
        private DateRange ExtendDateRange(DateRange dateRange) 
        {
            if (dateRange.Start < DateTime.Now.AddDays(6))
            {
                int difference = FindDifference(dateRange);
                return new DateRange(dateRange.Start.AddDays(difference), dateRange.End.AddDays(5));
            }
            else 
            {
                return new DateRange(dateRange.Start.AddDays(-5), dateRange.End.AddDays(5));
            }
        }
        private int FindDifference(DateRange dateRange) 
        {
            if (dateRange.Start < DateTime.Now.AddDays(1)) return 0;
            if (dateRange.Start < DateTime.Now.AddDays(2)) return -1;
            if (dateRange.Start < DateTime.Now.AddDays(3)) return -2;
            if (dateRange.Start < DateTime.Now.AddDays(4)) return -3;
            if (dateRange.Start < DateTime.Now.AddDays(5)) return -4;
            return -5;
        }
        private WorkTime CheckIfDateRangeOverlaps(DateRange dateRange, WorkTime workTime)
        {
            if (workTime.DateRange.Start.CompareTo(dateRange.Start) <= 0 && workTime.DateRange.End.CompareTo(dateRange.Start) > 0)
            {
                if (workTime.DateRange.End.CompareTo(dateRange.End) < 0)
                {
                    DateRange commonDateRange = new DateRange(dateRange.Start, workTime.DateRange.End);
                    return new WorkTime(commonDateRange, workTime.StartTime, workTime.EndTime);
                }
                else
                {
                    return new WorkTime(dateRange, workTime.StartTime, workTime.EndTime);
                }
            }
            else if (workTime.DateRange.Start.CompareTo(dateRange.End) < 0 && workTime.DateRange.End.CompareTo(dateRange.End) >= 0)
            {
                if (workTime.DateRange.Start.CompareTo(dateRange.Start) > 0)
                {
                    DateRange commonDateRange = new DateRange(workTime.DateRange.Start, dateRange.End);
                    return new WorkTime(commonDateRange, workTime.StartTime, workTime.EndTime);
                }
                else
                {
                    return new WorkTime(dateRange, workTime.StartTime, workTime.EndTime);
                }
            }
            else if (workTime.DateRange.Start.CompareTo(dateRange.Start) >= 0 && workTime.DateRange.End.CompareTo(dateRange.End) <= 0) 
            {
                return workTime;
            }
            return null;
        }

        public void SetAppointmentToFinish(int appointmentId)
        {
            //Appointment appointment = _appointmentRepository.GetById(appointmentId);
            //appointment.IsFinished = true;
            //_appointmentRepository.Update(appointment);
        }
        
        public Dictionary<int, int> GetDoctorWorkloadForDateRangeByDays(int doctorId, DateTime startDate, DateTime endDate)
        {
            PhysicianSchedule physicianSchedule = _physicianScheduleRepository.Get(doctorId);
            Dictionary<int, int> doctorWorkload = new Dictionary<int, int>();

            for(int i = 0; i <= endDate.Day - startDate.Day; i++)
            {
                int numberOfAppointmentsForDay = physicianSchedule.Get(doctorId, startDate.AddDays(i), startDate.AddDays(i+1)).Count;
                doctorWorkload.Add(startDate.Day + i, numberOfAppointmentsForDay);
            }
            return doctorWorkload;
        }

        public Dictionary<int, int> GetDoctorWorkloadForDateRangeByMonths(int doctorId, DateTime startDate, DateTime endDate)
        {
            PhysicianSchedule physicianSchedule = _physicianScheduleRepository.Get(doctorId);
            Dictionary<int, int> doctorWorkload = new Dictionary<int, int>();

            for (int i = 0; i <= endDate.Month - startDate.Month; i++)
            {
                int numberOfAppointmentsForMonth = physicianSchedule.Get(doctorId, startDate.AddMonths(i), startDate.AddMonths(i + 1)).Count;
                doctorWorkload.Add(startDate.Month + i, numberOfAppointmentsForMonth);
            }
            return doctorWorkload;

        }
    }
}
