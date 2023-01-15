using HospitalAPI.Dtos;
using HospitalAPI.Registration.Dtos;
using HospitalLibrary.Core.Model;
using Npgsql.TypeHandlers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Mappers
{
    public class AppointmentMapper : IGenericMapper<Appointment, AppointmentDTO>
    {
        private readonly IGenericMapper<DateRange, DateRangeDTO> _dateRangeMapper;
        private readonly IGenericMapper<Patient, PatientDTO> _patientMapper;

        public AppointmentMapper(IGenericMapper<DateRange, DateRangeDTO> dateRangeMapper, IGenericMapper<Patient, PatientDTO> patientMapper)
        {
            _dateRangeMapper = dateRangeMapper;
            _patientMapper = patientMapper;
        }

        public Appointment ToModel(AppointmentDTO appointmentDTO) {
            Appointment appointment = new Appointment();
            appointment.Id = appointmentDTO.Id;
            string hours = appointmentDTO.Time.Split(":")[0];
            string minutes = appointmentDTO.Time.Split(":")[1];
            DateTime start = appointmentDTO.Date.AddHours(Int32.Parse(hours)).AddMinutes(Int32.Parse(minutes));
            DateTime end = start.AddMinutes(30);
            appointment.ScheduledDate = _dateRangeMapper.ToModel(new DateRangeDTO(start, end));
            appointment.PatientId = appointmentDTO.PatientId;
            appointment.DoctorId = appointmentDTO.DoctorId;
            appointment.IsFinished = appointmentDTO.IsFinished;

            return appointment;
        }

        public List<Appointment> ToModel(List<AppointmentDTO> appointmentDTOs) {
            List<Appointment> appointments = new List<Appointment>();
            foreach (var appointmentDTO in appointmentDTOs) 
            {
                Appointment appointment = new Appointment();
                appointment.Id = appointmentDTO.Id;
                string hours = appointmentDTO.Time.Split(":")[0];
                string minutes = appointmentDTO.Time.Split(":")[1];
                DateTime start = appointmentDTO.Date.AddHours(Int32.Parse(hours)).AddMinutes(Int32.Parse(minutes));
                DateTime end = start.AddMinutes(30);
                appointment.ScheduledDate = _dateRangeMapper.ToModel(new DateRangeDTO(start, end));
                appointment.PatientId = appointmentDTO.PatientId;
                appointment.DoctorId = appointmentDTO.DoctorId;
                appointment.IsFinished = appointmentDTO.IsFinished;
                appointments.Add(appointment);
            }

            return appointments; 
        }

        public AppointmentDTO ToDTO(Appointment appointment) {
            AppointmentDTO appointmentDTO = new AppointmentDTO();
            appointmentDTO.Id = appointment.Id;
            appointmentDTO.Date = appointment.ScheduledDate.Start;
            appointmentDTO.Time = appointment.ScheduledDate.Start.ToString("HH:mm");
            appointmentDTO.PatientId = (int)appointment.PatientId;
            if(appointment.Patient != null)appointmentDTO.Patient = _patientMapper.ToDTO(appointment.Patient);
            appointmentDTO.DoctorId = appointment.DoctorId;
            appointmentDTO.IsFinished = appointment.IsFinished;

            return appointmentDTO;
        }

        public List<AppointmentDTO> ToDTO(List<Appointment> appointments) {
            List<AppointmentDTO> appointmentDTOs = new List<AppointmentDTO>();
            foreach (var appointment in appointments) 
            {
                AppointmentDTO appointmentDTO = new AppointmentDTO();
                appointmentDTO.Id = appointment.Id;
                appointmentDTO.Date = appointment.ScheduledDate.Start;
                appointmentDTO.Time = appointment.ScheduledDate.Start.ToString("HH:mm");
                appointmentDTO.PatientId = (int)appointment.PatientId;
                if (appointment.Patient != null) appointmentDTO.Patient = _patientMapper.ToDTO(appointment.Patient);
                appointmentDTO.DoctorId = appointment.DoctorId;
                appointmentDTO.IsFinished = appointment.IsFinished;
                appointmentDTOs.Add(appointmentDTO);
            }

            return appointmentDTOs;
        }
    }
}
