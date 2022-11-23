using HospitalAPI.Dtos;
using HospitalAPI.Registration.Dtos;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Mappers
{
    public class InpatientTreatmentMapper : IGenericMapper<InpatientTreatment, InpatientTreatmentDTO>
    {
        private readonly IGenericMapper<Room, RoomDTO> _roomMapper;
        private readonly IGenericMapper<Bed, BedDTO> _bedMapper;
        private readonly IGenericMapper<Patient, PatientDTO> _patientMapper;

        public InpatientTreatmentMapper(IGenericMapper<Room, RoomDTO> roomMapper, IGenericMapper<Bed, BedDTO> bedMapper, IGenericMapper<Patient, PatientDTO> patientMapper) {
            _roomMapper = roomMapper;
            _bedMapper = bedMapper;
            _patientMapper = patientMapper;
        }

        public InpatientTreatmentDTO ToDTO(InpatientTreatment inpatientTreatment)
        {
            InpatientTreatmentDTO inpatientTreatmentDTO = new InpatientTreatmentDTO();
            inpatientTreatmentDTO.InpatientTreatmentId = inpatientTreatment.InpatientTreatmentId;
            inpatientTreatmentDTO.PatientId = inpatientTreatment.PatientId;
            inpatientTreatmentDTO.Patient = _patientMapper.ToDTO(inpatientTreatment.Patient);
            inpatientTreatmentDTO.ReasonForAdmission = inpatientTreatment.ReasonForAdmission;
            inpatientTreatmentDTO.RoomId = inpatientTreatment.RoomId;
            inpatientTreatmentDTO.Room = _roomMapper.ToDTO(inpatientTreatment.Room);
            inpatientTreatmentDTO.BedId = inpatientTreatment.BedId;
            inpatientTreatmentDTO.Bed = _bedMapper.ToDTO(inpatientTreatment.Bed);
            inpatientTreatmentDTO.DateOfAdmission = inpatientTreatment.DateOfAdmission;
            return inpatientTreatmentDTO;
        }

        public List<InpatientTreatmentDTO> ToDTO(List<InpatientTreatment> inpatientTreatments)
        {
            List<InpatientTreatmentDTO> inpatientTreatmentDTOs = new List<InpatientTreatmentDTO>();
            foreach (var inpatientTreatment in inpatientTreatments) {
                InpatientTreatmentDTO inpatientTreatmentDTO = new InpatientTreatmentDTO();
                inpatientTreatmentDTO.InpatientTreatmentId = inpatientTreatment.InpatientTreatmentId;
                inpatientTreatmentDTO.PatientId = inpatientTreatment.PatientId;
                inpatientTreatmentDTO.Patient = _patientMapper.ToDTO(inpatientTreatment.Patient);
                inpatientTreatmentDTO.ReasonForAdmission = inpatientTreatment.ReasonForAdmission;
                inpatientTreatmentDTO.RoomId = inpatientTreatment.RoomId;
                inpatientTreatmentDTO.Room = _roomMapper.ToDTO(inpatientTreatment.Room);
                inpatientTreatmentDTO.BedId = inpatientTreatment.BedId;
                inpatientTreatmentDTO.Bed = _bedMapper.ToDTO(inpatientTreatment.Bed);
                inpatientTreatmentDTO.DateOfAdmission = inpatientTreatment.DateOfAdmission;
                inpatientTreatmentDTOs.Add(inpatientTreatmentDTO);
            }

            return inpatientTreatmentDTOs;
        }

        public InpatientTreatment ToModel(InpatientTreatmentDTO inpatientTreatmentDTO)
        {
            InpatientTreatment inpatientTreatment = new InpatientTreatment();
            inpatientTreatment.InpatientTreatmentId = inpatientTreatmentDTO.InpatientTreatmentId;
            inpatientTreatment.PatientId = inpatientTreatmentDTO.PatientId;
            //inpatientTreatment.Patient = _patientMapper.ToModel(inpatientTreatmentDTO.Patient);
            inpatientTreatment.ReasonForAdmission = inpatientTreatmentDTO.ReasonForAdmission;
            inpatientTreatment.RoomId = inpatientTreatmentDTO.RoomId;
            //inpatientTreatment.Room = _roomMapper.ToModel(inpatientTreatmentDTO.Room);
            inpatientTreatment.BedId = inpatientTreatmentDTO.BedId;
            //inpatientTreatment.Bed = _bedMapper.ToModel(inpatientTreatmentDTO.Bed);
            inpatientTreatment.DateOfAdmission = inpatientTreatmentDTO.DateOfAdmission;
            return inpatientTreatment;
        }

        public List<InpatientTreatment> ToModel(List<InpatientTreatmentDTO> inpatientTreatmentDTOs)
        {
            List<InpatientTreatment> inpatientTreatments = new List<InpatientTreatment>();
            foreach (var inpatientTreatmentDTO in inpatientTreatmentDTOs) {
                InpatientTreatment inpatientTreatment = new InpatientTreatment();
                inpatientTreatment.InpatientTreatmentId = inpatientTreatmentDTO.InpatientTreatmentId;
                inpatientTreatment.PatientId = inpatientTreatmentDTO.PatientId;
                //inpatientTreatment.Patient = _patientMapper.ToModel(inpatientTreatmentDTO.Patient);
                inpatientTreatment.ReasonForAdmission = inpatientTreatmentDTO.ReasonForAdmission;
                inpatientTreatment.RoomId = inpatientTreatmentDTO.RoomId;
                //inpatientTreatment.Room = _roomMapper.ToModel(inpatientTreatmentDTO.Room);
                inpatientTreatment.BedId = inpatientTreatmentDTO.BedId;
                //inpatientTreatment.Bed = _bedMapper.ToModel(inpatientTreatmentDTO.Bed);
                inpatientTreatment.DateOfAdmission = inpatientTreatmentDTO.DateOfAdmission;
                inpatientTreatments.Add(inpatientTreatment);
            }

            return inpatientTreatments;
        }
    }
}
