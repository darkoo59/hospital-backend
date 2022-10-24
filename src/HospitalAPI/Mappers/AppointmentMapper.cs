﻿using HospitalAPI.Dtos;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Mappers
{
    public class AppointmentMapper
    {
        public Appointment ToModel(AppointmentDTO appointmentDTO) {
            Appointment appointment = new Appointment();
            appointment.AppointmentId = appointmentDTO.AppointmentId;
            string hours = appointmentDTO.Time.Split(":")[0];
            string minutes = appointmentDTO.Time.Split(":")[1];
            appointment.DateTime = appointmentDTO.Date;
            // because of time zone mapping 
            appointment.DateTime = appointment.DateTime.AddHours(1);
            appointment.DateTime = appointment.DateTime.AddHours(Int32.Parse(hours));
            appointment.DateTime = appointment.DateTime.AddMinutes(Int32.Parse(minutes));
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
                appointment.DateTime = appointmentDTO.Date;
                appointment.DateTime.AddHours(Int32.Parse(hours));
                appointment.DateTime.AddMinutes(Int32.Parse(minutes));
                appointment.PatientId = appointmentDTO.PatientId;
                appointment.DoctorId = appointmentDTO.DoctorId;
                appointments.Add(appointment);
            }

            return appointments; 
        }

        public AppointmentDTO ToDTO(Appointment appointment) {
            AppointmentDTO appointmentDTO = new AppointmentDTO();
            appointmentDTO.AppointmentId = appointment.AppointmentId;
            appointmentDTO.Date = appointment.DateTime.Date;
            appointmentDTO.Time = appointment.DateTime.Hour.ToString() + ":" + appointment.DateTime.Minute.ToString();
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
                appointmentDTO.Date = appointment.DateTime.Date;
                appointmentDTO.Time = appointment.DateTime.Hour.ToString() + ":" + appointment.DateTime.Minute.ToString();
                appointmentDTO.DoctorId = (int)appointment.DoctorId;
                appointmentDTO.PatientId = (int)appointment.PatientId;
                appointmentDTOs.Add(appointmentDTO);
            }

            return appointmentDTOs;
        }
    }
}
