using HospitalAPI.Dtos;
using HospitalLibrary.Core.Model;
using System.Collections.Generic;

namespace HospitalAPI.Mappers
{
    public class SpecializationMapper : IGenericMapper<Specialization, SpecializationDTO>
    {
        public SpecializationDTO ToDTO(Specialization specialization)
        {
            SpecializationDTO specializationDTO = new SpecializationDTO();
            specializationDTO.Name = specialization.Name;
            specializationDTO.SpecializationId = specialization.SpecializationId;
            return specializationDTO;
        }

        public List<SpecializationDTO> ToDTO(List<Specialization> specializations)
        {
            List<SpecializationDTO> specializationDTOs = new List<SpecializationDTO>();

            foreach (var specilization in specializations)
            {
                SpecializationDTO specializationDTO = new SpecializationDTO();
                specializationDTO.Name = specilization.Name;
                specializationDTO.SpecializationId = specilization.SpecializationId;
                specializationDTOs.Add(specializationDTO);
            }
            return specializationDTOs;
        }

        public Specialization ToModel(SpecializationDTO specializationDTO)
        {
            Specialization specialization = new Specialization();
            specialization.SpecializationId = specializationDTO.SpecializationId;
            specialization.Name = specializationDTO.Name;
            return specialization;
        }

        public List<Specialization> ToModel(List<SpecializationDTO> specializationDTOs)
        {
            List<Specialization> specializations = new List<Specialization>();

            foreach (var specializationDTO in specializationDTOs)
            {
                Specialization specialization = new Specialization();
                specialization.Name = specializationDTO.Name;
                specialization.SpecializationId = specializationDTO.SpecializationId;
                specializations.Add(specialization);
            }
            return specializations;
        }
    }
}
