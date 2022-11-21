using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalAPI.Dtos;
using HospitalLibrary.Core.Model;

namespace HospitalAPI.Mappers
{
    public class MedicineTherapyMapper : IGenericMapper<MedicineTherapy, MedicineTherapyDTO>
    {

        private readonly IGenericMapper<Medicine, MedicineDTO> _medicineMapper;

        public MedicineTherapyMapper(IGenericMapper<Medicine, MedicineDTO> medicineMapper)
        {
            _medicineMapper = medicineMapper;
        }
        public MedicineTherapyDTO ToDTO(MedicineTherapy medicineTherapy)
        {
            MedicineTherapyDTO medicineTherapyDTO = new MedicineTherapyDTO();
            medicineTherapyDTO.MedicineTherapyId = medicineTherapy.MedicineTherapyId;
            medicineTherapyDTO.MedicineId = medicineTherapy.MedicineId;
            medicineTherapyDTO.Medicine = _medicineMapper.ToDTO(medicineTherapy.Medicine);
            medicineTherapyDTO.Dosage = medicineTherapy.Dosage;
            medicineTherapyDTO.Start = medicineTherapy.Start;
            medicineTherapyDTO.End = medicineTherapy.End;
            return medicineTherapyDTO;
        }

        public List<MedicineTherapyDTO> ToDTO(List<MedicineTherapy> medicineTherapies)
        {
            List<MedicineTherapyDTO> medicineTherapyDTOs = new List<MedicineTherapyDTO>();
            foreach (var medicineTherapy in medicineTherapies)
            {
                MedicineTherapyDTO medicineTherapyDTO = new MedicineTherapyDTO();
                medicineTherapyDTO.MedicineTherapyId = medicineTherapy.MedicineTherapyId;
                medicineTherapyDTO.MedicineId = medicineTherapy.MedicineId;
                medicineTherapyDTO.Medicine = _medicineMapper.ToDTO(medicineTherapy.Medicine);
                medicineTherapyDTO.Dosage = medicineTherapy.Dosage;
                medicineTherapyDTO.Start = medicineTherapy.Start;
                medicineTherapyDTO.End = medicineTherapy.End;
                medicineTherapyDTOs.Add(medicineTherapyDTO);
            }

            return medicineTherapyDTOs;
        }

        public MedicineTherapy ToModel(MedicineTherapyDTO medicineTherapyDTO)
        {
            MedicineTherapy medicineTherapy = new MedicineTherapy();
            medicineTherapy.MedicineTherapyId = medicineTherapyDTO.MedicineTherapyId;
            medicineTherapy.MedicineId = medicineTherapyDTO.MedicineId;
            medicineTherapy.Dosage = medicineTherapyDTO.Dosage;
            medicineTherapy.Start = medicineTherapyDTO.Start;
            medicineTherapy.End = medicineTherapyDTO.End;
            return medicineTherapy;
        }

        public List<MedicineTherapy> ToModel(List<MedicineTherapyDTO> medicineTherapyDTOs)
        {
            List<MedicineTherapy> medicineTherapies = new List<MedicineTherapy>();
            foreach (var medicineTherapyDTO in medicineTherapyDTOs)
            {
                MedicineTherapy medicineTherapy = new MedicineTherapy();
                medicineTherapy.MedicineTherapyId = medicineTherapyDTO.MedicineTherapyId;
                medicineTherapy.MedicineId = medicineTherapyDTO.MedicineId;
                medicineTherapy.Dosage = medicineTherapyDTO.Dosage;
                medicineTherapy.Start = medicineTherapyDTO.Start;
                medicineTherapy.End = medicineTherapyDTO.End;
                medicineTherapies.Add(medicineTherapy);
            }

            return medicineTherapies;
        }
    }
}
