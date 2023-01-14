using System;
﻿using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;

namespace HospitalLibrary.Core.Service
{
    public class PhysicianScheduleService : IPhysicianScheduleService
    {
        private readonly IPhysicianScheduleRepository _physicianScheduleRepository;
        public PhysicianScheduleService(IPhysicianScheduleRepository physicianScheduleRepository)
        {
            _physicianScheduleRepository = physicianScheduleRepository;
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
            throw new NotImplementedException();
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
