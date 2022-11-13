using HospitalAPI.Dtos;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;

namespace HospitalAPI.Mappers
{
    public class DoctorMapper : IGenericMapper<Doctor, DoctorDTO>
    {
        public DoctorDTO ToDTO(Doctor doctor)
        {
            DoctorDTO doctorDTO = new DoctorDTO();
            doctorDTO.DoctorId = doctor.DoctorId;
            doctorDTO.Name = doctor.Name;
            doctorDTO.Surname = doctor.Surname;
            doctorDTO.RoomId = doctor.RoomId;
            doctorDTO.SpecializationId = doctor.SpecializationId;

            return doctorDTO;
        }

        public List<DoctorDTO> ToDTO(List<Doctor> doctors)
        {
            List<DoctorDTO> doctorDTOs = new List<DoctorDTO>();
            foreach (var doctor in doctors)
            {
                DoctorDTO doctorDTO = new DoctorDTO();
                doctorDTO.DoctorId = doctor.DoctorId;
                doctorDTO.Name = doctor.Name;
                doctorDTO.Surname = doctor.Surname;
                doctorDTO.RoomId = doctor.RoomId;
                doctorDTO.SpecializationId = doctor.SpecializationId;

                doctorDTOs.Add(doctorDTO);
            }

            return doctorDTOs;
        }

        public Doctor ToModel(DoctorDTO doctorDTO)
        {
            Doctor doctor = new Doctor();
            doctor.DoctorId = doctorDTO.DoctorId;
            doctor.Name = doctorDTO.Name;
            doctor.Surname = doctorDTO.Surname;
            doctor.RoomId = doctorDTO.RoomId;
            doctor.SpecializationId = doctorDTO.SpecializationId;

            return doctor;
        }

        public List<Doctor> ToModel(List<DoctorDTO> doctorDTOs)
        {
            List<Doctor> doctors = new List<Doctor>();
            foreach (var doctorDTO in doctorDTOs)
            {
                Doctor doctor = new Doctor();
                doctor.DoctorId = doctorDTO.DoctorId;
                doctor.Name = doctorDTO.Name;
                doctor.Surname = doctorDTO.Surname;
                doctor.RoomId = doctorDTO.RoomId;
                doctor.SpecializationId = doctorDTO.SpecializationId;
                doctors.Add(doctor);
            }
            return doctors;
        }
    }
}
