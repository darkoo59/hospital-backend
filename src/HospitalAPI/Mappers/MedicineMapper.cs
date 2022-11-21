using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalAPI.Dtos;
using HospitalLibrary.Core.Model;

namespace HospitalAPI.Mappers
{
    public class MedicineMapper : IGenericMapper<Medicine, MedicineDTO>
    {
        public MedicineDTO ToDTO(Medicine medicine)
        {
            MedicineDTO medicineDTO = new MedicineDTO();
            medicineDTO.MedicineId = medicine.MedicineId;
            medicineDTO.Name = medicine.Name;
            medicineDTO.Manufacturer = medicine.Manufacturer;
            return medicineDTO;
        }

        public List<MedicineDTO> ToDTO(List<Medicine> medicines)
        {
            List<MedicineDTO> medicineDTOs = new List<MedicineDTO>();
            foreach (var medicine in medicines)
            {
                MedicineDTO medicineDTO = new MedicineDTO();
                medicineDTO.MedicineId = medicine.MedicineId;
                medicineDTO.Name = medicine.Name;
                medicineDTO.Manufacturer = medicine.Manufacturer;
                medicineDTOs.Add(medicineDTO);
            }

            return medicineDTOs;
        }

        public Medicine ToModel(MedicineDTO medicineDTO)
        {
            Medicine medicine = new Medicine();
            medicine.MedicineId = medicineDTO.MedicineId;
            medicine.Name = medicineDTO.Name;
            medicine.Manufacturer = medicineDTO.Manufacturer;
            return medicine;
        }

        public List<Medicine> ToModel(List<MedicineDTO> medicineDTOs)
        {
            List<Medicine> medicines = new List<Medicine>();
            foreach (var medicineDTO in medicineDTOs)
            {
                Medicine medicine = new Medicine();
                medicine.MedicineId = medicineDTO.MedicineId;
                medicine.Name = medicineDTO.Name;
                medicine.Manufacturer = medicineDTO.Manufacturer;
            }

            return medicines;
        }
    }
}
