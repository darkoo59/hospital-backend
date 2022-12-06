using HospitalAPI.Dtos;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Mappers
{
    public class AppointmentMapper : IGenericMapper<Appointment, AppointmentDTO>
    {
        public Appointment ToModel(AppointmentDTO appointmentDTO) {
            Appointment appointment = new Appointment();
            appointment.AppointmentId = appointmentDTO.AppointmentId;
            string hours = appointmentDTO.Time.Split(":")[0];
            string minutes = appointmentDTO.Time.Split(":")[1];
            DateTime date = appointmentDTO.Date.AddHours(Int32.Parse(hours)).AddMinutes(Int32.Parse(minutes));
            appointment.ScheduledDate = new DateRange(date, date.AddMinutes(30));
            appointment.PatientId = appointmentDTO.PatientId;
            appointment.DoctorId = appointmentDTO.DoctorId;

            return appointment;
        }

        public List<Appointment> ToModel(List<AppointmentDTO> appointmentDTOs) {
            List<Appointment> appointments = new List<Appointment>();
            foreach (var appointmentDTO in appointmentDTOs) 
            {
                Appointment appointment = new Appointment();
                appointment.AppointmentId = appointmentDTO.AppointmentId;
                string hours = appointmentDTO.Time.Split(":")[0];
                string minutes = appointmentDTO.Time.Split(":")[1];
                DateTime start = appointmentDTO.Date.AddHours(Int32.Parse(hours)).AddMinutes(Int32.Parse(minutes));
                DateTime end = appointmentDTO.Date.AddHours(Int32.Parse(hours)).AddMinutes(Int32.Parse(minutes));
                //appointment.ScheduledDate = new DateRange(start, end.AddMinutes(30));
                appointment.PatientId = appointmentDTO.PatientId;
                appointment.DoctorId = appointmentDTO.DoctorId;
                appointments.Add(appointment);
            }

            return appointments; 
        }

        public AppointmentDTO ToDTO(Appointment appointment) {
            AppointmentDTO appointmentDTO = new AppointmentDTO();
            appointmentDTO.AppointmentId = appointment.AppointmentId;
            appointmentDTO.Date = appointment.ScheduledDate.Start;
            appointmentDTO.Time = appointment.ScheduledDate.Start.Hour.ToString() + ":" + appointment.ScheduledDate.Start.Minute.ToString();
            appointmentDTO.DoctorId = (int)appointment.DoctorId;
            appointmentDTO.PatientId = (int)appointment.PatientId;

            return appointmentDTO;
        }

        public List<AppointmentDTO> ToDTO(List<Appointment> appointments) {
            List<AppointmentDTO> appointmentDTOs = new List<AppointmentDTO>();
            foreach (var appointment in appointments) 
            {
                AppointmentDTO appointmentDTO = new AppointmentDTO();
                appointmentDTO.AppointmentId = appointment.AppointmentId;
                appointmentDTO.Date = appointment.ScheduledDate.Start;
                appointmentDTO.Time = appointment.ScheduledDate.Start.Hour.ToString() + ":" + appointment.ScheduledDate.Start.Minute.ToString();
                appointmentDTO.DoctorId = (int)appointment.DoctorId;
                appointmentDTO.PatientId = (int)appointment.PatientId;
                appointmentDTOs.Add(appointmentDTO);
            }

            return appointmentDTOs;
        }
    }
}
