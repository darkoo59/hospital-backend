using HospitalAPI.Mappers;
using HospitalAPI.Registration.Dtos;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;

namespace HospitalAPI.Registration.Mappers
{
    public class MedicalRecordMapper : IGenericMapper<MedicalRecord, PatientDTO>
    {
        
        public PatientDTO ToDTO(MedicalRecord model)
        {
            throw new System.NotImplementedException();
        }

        public List<PatientDTO> ToDTO(List<MedicalRecord> model)
        {
            throw new System.NotImplementedException();
        }

        public MedicalRecord ToModel(PatientDTO patientDTO)
        {
            MedicalRecord medicalRecord = new MedicalRecord();

            BloodType bloodType;

            if (patientDTO.BloodType.Equals("AB+"))
            {
                bloodType = BloodType.AB_PLUS;
            }
            else if (patientDTO.BloodType.Equals("AB-"))
            {
                bloodType = BloodType.AB_MINUS;
            }
            else if (patientDTO.BloodType.Equals("A+"))
            {
                bloodType = BloodType.A_PLUS;
            }
            else if (patientDTO.BloodType.Equals("A-"))
            {
                bloodType = BloodType.A_MINUS;
            }
            else if (patientDTO.BloodType.Equals("B+"))
            {
                bloodType = BloodType.B_PLUS;
            }
            else if (patientDTO.BloodType.Equals("B-"))
            {
                bloodType = BloodType.B_MINUS;
            }
            else if (patientDTO.BloodType.Equals("O+"))
            {
                bloodType = BloodType.O_PLUS;
            }
            else if (patientDTO.BloodType.Equals("O-"))
            {
                bloodType = BloodType.O_MINUS;
            }
            else
            {
                bloodType = BloodType.O_PLUS;
                Console.WriteLine("Nije dobavio blood type kako treba.");
            }

            medicalRecord.BloodType = bloodType;

            medicalRecord.Allergens = new List<Allergen>();

            return medicalRecord;
        }

        public List<MedicalRecord> ToModel(List<PatientDTO> dto)
        {
            throw new System.NotImplementedException();
        }
    }
}
