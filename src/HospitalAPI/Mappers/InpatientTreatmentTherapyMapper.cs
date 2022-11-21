using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalAPI.Dtos;
using HospitalLibrary.Core.Model;

namespace HospitalAPI.Mappers
{
    public class InpatientTreatmentTherapyMapper : IGenericMapper<InpatientTreatmentTherapy, InpatientTreatmentTherapyDTO>
    {

        private readonly IGenericMapper<InpatientTreatment, InpatientTreatmentDTO> _inpatientTreatmentMapper;
        private readonly IGenericMapper<MedicineTherapy, MedicineTherapyDTO> _medicineTherapyMapper;
        private readonly IGenericMapper<BloodTherapy, BloodTherapyDTO> _bloodTherapyMapper;

        public InpatientTreatmentTherapyMapper(IGenericMapper<InpatientTreatment, InpatientTreatmentDTO> inpatientTreatmentMapper, IGenericMapper<MedicineTherapy, MedicineTherapyDTO> medicineTherapyMapper, IGenericMapper<BloodTherapy, BloodTherapyDTO> bloodTherapyMapper)
        {
            _inpatientTreatmentMapper = inpatientTreatmentMapper;
            _medicineTherapyMapper = medicineTherapyMapper;
            _bloodTherapyMapper = bloodTherapyMapper;
        }
        public InpatientTreatmentTherapyDTO ToDTO(InpatientTreatmentTherapy inpatientTreatmentTherapy)
        {
            InpatientTreatmentTherapyDTO inpatientTreatmentTherapyDTO = new InpatientTreatmentTherapyDTO();
            inpatientTreatmentTherapyDTO.InpatientTreatmentTherapyId = inpatientTreatmentTherapy.InpatientTreatmentTherapyId;
            inpatientTreatmentTherapyDTO.InpatientTreatmentId = inpatientTreatmentTherapy.InpatientTreatmentId;
            inpatientTreatmentTherapyDTO.InpatientTreatment = _inpatientTreatmentMapper.ToDTO(inpatientTreatmentTherapy.InpatientTreatment);
            inpatientTreatmentTherapyDTO.MedicineTherapies = _medicineTherapyMapper.ToDTO(inpatientTreatmentTherapy.MedicineTherapies);
            inpatientTreatmentTherapyDTO.BloodTherapies = _bloodTherapyMapper.ToDTO(inpatientTreatmentTherapy.BloodTherapies);
            return inpatientTreatmentTherapyDTO;
        }

        public List<InpatientTreatmentTherapyDTO> ToDTO(List<InpatientTreatmentTherapy> inpatientTreatmentTherapies)
        {
            List<InpatientTreatmentTherapyDTO> inpatientTreatmentTherapyDTOs = new List<InpatientTreatmentTherapyDTO>();
            foreach (var inpatientTreatmentTherapy in inpatientTreatmentTherapies)
            {
                InpatientTreatmentTherapyDTO inpatientTreatmentTherapyDTO = new InpatientTreatmentTherapyDTO();
                inpatientTreatmentTherapyDTO.InpatientTreatmentTherapyId = inpatientTreatmentTherapy.InpatientTreatmentTherapyId;
                inpatientTreatmentTherapyDTO.InpatientTreatmentId = inpatientTreatmentTherapy.InpatientTreatmentId;
                inpatientTreatmentTherapyDTO.InpatientTreatment = _inpatientTreatmentMapper.ToDTO(inpatientTreatmentTherapy.InpatientTreatment);
                inpatientTreatmentTherapyDTO.MedicineTherapies = _medicineTherapyMapper.ToDTO(inpatientTreatmentTherapy.MedicineTherapies);
                inpatientTreatmentTherapyDTO.BloodTherapies = _bloodTherapyMapper.ToDTO(inpatientTreatmentTherapy.BloodTherapies);
                inpatientTreatmentTherapyDTOs.Add(inpatientTreatmentTherapyDTO);
            }

            return inpatientTreatmentTherapyDTOs;
        }

        public InpatientTreatmentTherapy ToModel(InpatientTreatmentTherapyDTO inpatientTreatmentTherapyDTO)
        {
            InpatientTreatmentTherapy inpatientTreatmentTherapy = new InpatientTreatmentTherapy();
            inpatientTreatmentTherapy.InpatientTreatmentTherapyId = inpatientTreatmentTherapyDTO.InpatientTreatmentTherapyId;
            inpatientTreatmentTherapy.InpatientTreatmentId = inpatientTreatmentTherapyDTO.InpatientTreatmentId;
            inpatientTreatmentTherapy.MedicineTherapies = _medicineTherapyMapper.ToModel(inpatientTreatmentTherapyDTO.MedicineTherapies);
            inpatientTreatmentTherapy.BloodTherapies = _bloodTherapyMapper.ToModel(inpatientTreatmentTherapyDTO.BloodTherapies);
            return inpatientTreatmentTherapy;
        }

        public List<InpatientTreatmentTherapy> ToModel(List<InpatientTreatmentTherapyDTO> inpatientTreatmentTherapyDTOs)
        {
            List<InpatientTreatmentTherapy> inpatientTreatmentTherapies = new List<InpatientTreatmentTherapy>();
            foreach (var inpatientTreatmentTherapyDTO in inpatientTreatmentTherapyDTOs)
            {
                InpatientTreatmentTherapy inpatientTreatmentTherapy = new InpatientTreatmentTherapy();
                inpatientTreatmentTherapy.InpatientTreatmentTherapyId = inpatientTreatmentTherapyDTO.InpatientTreatmentTherapyId;
                inpatientTreatmentTherapy.InpatientTreatmentId = inpatientTreatmentTherapyDTO.InpatientTreatmentId;
                inpatientTreatmentTherapy.MedicineTherapies = _medicineTherapyMapper.ToModel(inpatientTreatmentTherapyDTO.MedicineTherapies);
                inpatientTreatmentTherapy.BloodTherapies = _bloodTherapyMapper.ToModel(inpatientTreatmentTherapyDTO.BloodTherapies);
                inpatientTreatmentTherapies.Add(inpatientTreatmentTherapy);
            }

            return inpatientTreatmentTherapies;
        }
    }
}
