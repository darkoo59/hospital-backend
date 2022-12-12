using HospitalAPI.Dtos;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Mappers
{
    public class AppointmentMapper : IGenericMapper<Appointment, AppointmentDTO>
    {
        public Appointment ToModel(AppointmentDTO appointmentDTO) {
            Appointment appointment = new Appointment();
            appointment.Id = appointmentDTO.AppointmentId;
            string day = appointmentDTO.Date.Split("/")[1];
            string month = appointmentDTO.Date.Split("/")[0];
            string year = appointmentDTO.Date.Split("/")[2];
            string hours = appointmentDTO.Time.Split(":")[0];
            string minutes = appointmentDTO.Time.Split(":")[1];
            Console.WriteLine(day + " " + month + " " + year);
            DateTime date = new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day));
            DateTime start = date.AddHours(Int32.Parse(hours)).AddMinutes(Int32.Parse(minutes));
            DateTime end = date.AddHours(Int32.Parse(hours)).AddMinutes(Int32.Parse(minutes));
            appointment.ScheduledDate = new DateRange(date, date.AddMinutes(30));
            appointment.PatientId = appointmentDTO.PatientId;

            return appointment;
        }

        public List<Appointment> ToModel(List<AppointmentDTO> appointmentDTOs) {
            List<Appointment> appointments = new List<Appointment>();
            foreach (var appointmentDTO in appointmentDTOs) 
            {
                Appointment appointment = new Appointment();
                appointment.Id = appointmentDTO.AppointmentId;
                string day = appointmentDTO.Date.Split("/")[1];
                string month = appointmentDTO.Date.Split("/")[0];
                string year = appointmentDTO.Date.Split("/")[2];
                string hours = appointmentDTO.Time.Split(":")[0];
                string minutes = appointmentDTO.Time.Split(":")[1];
                DateTime date = new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day));  
                DateTime start = date.AddHours(Int32.Parse(hours)).AddMinutes(Int32.Parse(minutes));
                DateTime end = date.AddHours(Int32.Parse(hours)).AddMinutes(Int32.Parse(minutes));
                appointment.ScheduledDate = new DateRange(start, end.AddMinutes(30));
                appointment.PatientId = appointmentDTO.PatientId;
                appointments.Add(appointment);
            }

            return appointments; 
        }

        public AppointmentDTO ToDTO(Appointment appointment) {
            AppointmentDTO appointmentDTO = new AppointmentDTO();
            appointmentDTO.AppointmentId = appointment.Id;
            appointmentDTO.Date = appointment.ScheduledDate.Start.ToString("d", CultureInfo.GetCultureInfo("en-ES"));
            appointmentDTO.Time = appointment.ScheduledDate.Start.Hour.ToString() + ":" + appointment.ScheduledDate.Start.Minute.ToString();
            appointmentDTO.DoctorId = (int)appointment.DoctorId;
            appointmentDTO.PatientId = (int)appointment.PatientId;
            appointmentDTO.Name = appointment.Doctor.Name;
            appointmentDTO.Surname = appointment.Doctor.Surname;
            return appointmentDTO;
        }

        public List<AppointmentDTO> ToDTO(List<Appointment> appointments) {
            List<AppointmentDTO> appointmentDTOs = new List<AppointmentDTO>();
            foreach (var appointment in appointments) 
            {
                AppointmentDTO appointmentDTO = new AppointmentDTO();
                appointmentDTO.AppointmentId = appointment.Id;
                appointmentDTO.Date = appointment.ScheduledDate.Start.ToString("d", CultureInfo.GetCultureInfo("en-ES"));
                appointmentDTO.Time = appointment.ScheduledDate.Start.Hour.ToString() + ":" + appointment.ScheduledDate.Start.Minute.ToString();
                appointmentDTO.DoctorId = (int)appointment.DoctorId;
                appointmentDTO.PatientId = (int)appointment.PatientId;
                appointmentDTO.Name = appointment.Doctor.Name;
                appointmentDTO.Surname = appointment.Doctor.Surname;
                appointmentDTOs.Add(appointmentDTO);
            }

            return appointmentDTOs;
        }
    }
}
