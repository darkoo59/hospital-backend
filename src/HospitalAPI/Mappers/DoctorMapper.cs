using HospitalAPI.Dtos;
using HospitalLibrary.Core.Model;
using System.Collections.Generic;

namespace HospitalAPI.Mappers
{
    public class DoctorMapper : IGenericMapper<Doctor, DoctorDTO>
    {
        public Doctor ToModel(DoctorDTO doctorDTO)
        {
            Doctor doctor = new Doctor();
            doctor.DoctorId = doctorDTO.DoctorId;
            doctor.Name = doctorDTO.Name;
            doctor.Surname = doctorDTO.Surname;
            doctor.SpecializationId = doctorDTO.SpecializationId;
            doctor.RoomId = doctorDTO.RoomId;

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
                doctor.SpecializationId = doctorDTO.SpecializationId;
                doctor.RoomId = doctorDTO.RoomId;
                doctors.Add(doctor);
            }

            return doctors;
        }

        public DoctorDTO ToDTO(Doctor doctor)
        {
            if (doctor != null)
            {
                DoctorDTO doctorDTO = new DoctorDTO();
                doctorDTO.DoctorId = doctor.DoctorId;
                doctorDTO.Name = doctor.Name;
                doctorDTO.Surname = doctor.Surname;
                doctorDTO.SpecializationId = doctor.SpecializationId;
                doctorDTO.RoomId = doctor.RoomId;

                return doctorDTO;
            }

            return null;
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
                doctorDTO.SpecializationId = doctor.SpecializationId;
                doctorDTO.RoomId = doctor.RoomId;

                doctorDTOs.Add(doctorDTO);
            }
            
            return doctorDTOs;
        }
    }
}