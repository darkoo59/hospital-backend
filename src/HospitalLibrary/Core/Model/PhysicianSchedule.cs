using System;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Model
{
    public class PhysicianSchedule
    {
        public int PhysicianScheduleId { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public List<WorkTime> WorkTimes { get; set; }
        public List<Appointment> Appointments { get; set; }
        public List<Vacation> Vacations { get; set; }

        //public PhysicianSchedule(int physicianScheduleId, int doctorId, List<WorkTime> workTimes, List<Appointment> appointments, List<Vacation> vacations)
        //{
        //    DoctorId = doctorId;
        //    WorkTimes = workTimes;
        //    Appointments = appointments;
        //    Vacations = vacations;
        //}

        public bool IsAppointmentAvailable(Appointment appointment)
        {
            foreach (var a in Appointments)
            {
                if (a.Start.Hour == appointment.Start.Hour && a.Start.Minute == appointment.Start.Minute)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsDoctorOnVacation(Appointment appointment)
        {
            foreach (var vacation in Vacations)
            {
                if (appointment.Start >= vacation.StartDate && appointment.Start <= vacation.EndDate)
                {
                    return false;
                }
            }

            return true;
        }


        private static bool IsDoctorWorking(Appointment appointment, WorkTime workTime)
        {
            return appointment.Start >= workTime.DateRange.Start && appointment.Start <= workTime.DateRange.End && appointment.Start.TimeOfDay >= workTime.StartTime && appointment.Start.TimeOfDay <= workTime.EndTime;
        }

        private bool IsDoctorAvailable(Appointment appointment)
        {
            foreach (var workTime in WorkTimes)
            {
                if (IsDoctorWorking(appointment, workTime))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek.Equals(DayOfWeek.Saturday) || date.DayOfWeek.Equals(DayOfWeek.Sunday);
        }


        public bool IsAppointmentValid(Appointment appointment)
        {
            return IsAppointmentAvailable(appointment) && IsDoctorOnVacation(appointment) && IsDoctorAvailable(appointment) && !IsWeekend(appointment.Start);
        }


        public List<Appointment> Get(int doctorId, DateTime startDate, DateTime endDate)
        {
            List<Appointment> appointments = new List<Appointment>();
            foreach (Appointment appointment in Appointments)
            {
                if (appointment.Start > startDate && appointment.Start < endDate)
                {
                    appointments.Add(appointment);
                }
            }
            return appointments;
        }


    }
}
