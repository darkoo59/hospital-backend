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
                if (a.ScheduledDate.Start == appointment.ScheduledDate.Start)
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
                if (appointment.ScheduledDate.Start >= vacation.StartDate && appointment.ScheduledDate.Start <= vacation.EndDate)
                {
                    return false;
                }
            }

            return true;
        }


        private static bool IsDoctorWorking(Appointment appointment, WorkTime workTime)
        {
            return appointment.ScheduledDate.Start >= workTime.DateRange.Start && appointment.ScheduledDate.Start <= workTime.DateRange.End && appointment.ScheduledDate.Start.TimeOfDay >= workTime.TimeRange.Start && appointment.ScheduledDate.Start.TimeOfDay <= workTime.TimeRange.End;
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
            return IsAppointmentAvailable(appointment) && IsDoctorOnVacation(appointment) && IsDoctorAvailable(appointment) && !IsWeekend(appointment.ScheduledDate.Start);
        }


        public List<Appointment> Get(int doctorId, DateTime startDate, DateTime endDate)
        {
            List<Appointment> appointments = new List<Appointment>();
            foreach (Appointment appointment in Appointments)
            {
                if (appointment.ScheduledDate.Start > startDate && appointment.ScheduledDate.Start < endDate)
                {
                    appointments.Add(appointment);
                }
            }
            return appointments;
        }
    }
}
