using HospitalAPI.Dtos;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Mappers
{
    public class SymptomMapper : IGenericMapper<Symptom, SymptomDTO>
    {
        public SymptomDTO ToDTO(Symptom symptom)
        {
            SymptomDTO symptomDTO = new SymptomDTO();
            symptomDTO.SymptomId = symptom.SymptomId;
            symptomDTO.Name = symptom.Name;

            return symptomDTO;
        }

        public List<SymptomDTO> ToDTO(List<Symptom> symptoms)
        {
            List<SymptomDTO> symptomDTOs = new List<SymptomDTO>();
            foreach (var symptom in symptoms)
            {
                SymptomDTO symptomDTO = new SymptomDTO();
                symptomDTO.SymptomId = symptom.SymptomId;
                symptomDTO.Name = symptom.Name;
                symptomDTOs.Add(symptomDTO);
            }

            return symptomDTOs;
        }

        public Symptom ToModel(SymptomDTO symptomDTO)
        {
            Symptom symptom = new Symptom();
            symptom.SymptomId = symptomDTO.SymptomId;
            symptom.Name = symptomDTO.Name;
            return symptom;
        }

        public List<Symptom> ToModel(List<SymptomDTO> symptomDTOs)
        {
            List<Symptom> symptoms = new List<Symptom>();
            foreach (var symptomDTO in symptomDTOs)
            {
                Symptom symptom = new Symptom();
                symptom.SymptomId = symptomDTO.SymptomId;
                symptom.Name = symptomDTO.Name;
            }

            return symptoms;
        }
    }
}
