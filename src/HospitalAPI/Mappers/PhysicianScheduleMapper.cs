using HospitalAPI.Dtos;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Mappers
{
    public class PhysicianScheduleMapper : IGenericMapper<PhysicianSchedule, PhysicianScheduleDTO>
    {
        private readonly IGenericMapper<WorkTime, WorkTimeDTO> _workTimeMapper;
        private readonly IGenericMapper<Vacation, VacationDTO> _vacationMapper;
        private readonly IGenericMapper<Appointment, AppointmentDTO> _appointmentMapper;
        private readonly IGenericMapper<Doctor, DoctorDTO> _doctorMapper;

        public PhysicianScheduleMapper(IGenericMapper<WorkTime, WorkTimeDTO> workTimeMapper, IGenericMapper<Vacation, VacationDTO> vacationMapper, IGenericMapper<Appointment, AppointmentDTO> appointmentMapper, IGenericMapper<Doctor, DoctorDTO> doctorMapper)
        {
            _workTimeMapper = workTimeMapper;
            _vacationMapper = vacationMapper;
            _appointmentMapper = appointmentMapper;
            _doctorMapper = doctorMapper;
        }

        public PhysicianScheduleDTO ToDTO(PhysicianSchedule physicianSchedule)
        {
            PhysicianScheduleDTO physicianScheduleDTO = new PhysicianScheduleDTO();
            physicianScheduleDTO.PhysicianScheduleId = physicianSchedule.Id;
            physicianScheduleDTO.DoctorId = physicianSchedule.DoctorId;
            physicianScheduleDTO.Doctor = _doctorMapper.ToDTO(physicianSchedule.Doctor);
            physicianScheduleDTO.WorkTimes = _workTimeMapper.ToDTO(physicianSchedule.WorkTimes);
            physicianScheduleDTO.Appointments = _appointmentMapper.ToDTO(physicianSchedule.Appointments);
            physicianScheduleDTO.Vacations = _vacationMapper.ToDTO(physicianSchedule.Vacations);

            return physicianScheduleDTO;
        }

        public List<PhysicianScheduleDTO> ToDTO(List<PhysicianSchedule> physicianSchedules)
        {
            List<PhysicianScheduleDTO> physicianScheduleDTOs = new List<PhysicianScheduleDTO>();
            foreach (var physicianSchedule in physicianSchedules)
            {
                PhysicianScheduleDTO physicianScheduleDTO = new PhysicianScheduleDTO();
                physicianScheduleDTO.PhysicianScheduleId = physicianSchedule.Id;
                physicianScheduleDTO.DoctorId = physicianSchedule.DoctorId;
                physicianScheduleDTO.Doctor = _doctorMapper.ToDTO(physicianSchedule.Doctor);
                physicianScheduleDTO.WorkTimes = _workTimeMapper.ToDTO(physicianSchedule.WorkTimes);
                physicianScheduleDTO.Appointments = _appointmentMapper.ToDTO(physicianSchedule.Appointments);
                physicianScheduleDTO.Vacations = _vacationMapper.ToDTO(physicianSchedule.Vacations);
                physicianScheduleDTOs.Add(physicianScheduleDTO);
            }

            return physicianScheduleDTOs;
        }

        public PhysicianSchedule ToModel(PhysicianScheduleDTO physicianScheduleDTO)
        {
            return new PhysicianSchedule
            (
                physicianScheduleDTO.PhysicianScheduleId,
                physicianScheduleDTO.DoctorId,
                 _doctorMapper.ToModel(physicianScheduleDTO.Doctor),
                 _workTimeMapper.ToModel(physicianScheduleDTO.WorkTimes),
                 _appointmentMapper.ToModel(physicianScheduleDTO.Appointments),
                 _vacationMapper.ToModel(physicianScheduleDTO.Vacations)

            );
        }

        public List<PhysicianSchedule> ToModel(List<PhysicianScheduleDTO> physicianScheduleDTOs)
        {
            List<PhysicianSchedule> physicianSchedules = new List<PhysicianSchedule>();
            foreach (var physicianScheduleDTO in physicianScheduleDTOs)
            {
                physicianSchedules.Add(new PhysicianSchedule
                (
                    physicianScheduleDTO.PhysicianScheduleId,
                    physicianScheduleDTO.DoctorId,
                        _doctorMapper.ToModel(physicianScheduleDTO.Doctor),
                        _workTimeMapper.ToModel(physicianScheduleDTO.WorkTimes),
                        _appointmentMapper.ToModel(physicianScheduleDTO.Appointments),
                        _vacationMapper.ToModel(physicianScheduleDTO.Vacations)

                ));
            }

            return physicianSchedules;
        }
    }
}
