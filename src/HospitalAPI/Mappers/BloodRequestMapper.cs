using HospitalAPI.Dtos;
using HospitalAPI.Registration.Dtos;
using HospitalLibrary.Core.Model;
using HospitalLibrary.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Mappers
{
    public class BloodRequestMapper : IGenericMapper<BloodRequest, BloodRequestDTO>
    {
        public BloodRequestDTO ToDTO(BloodRequest bloodRequest)
        {
            BloodRequestDTO bloodRequestDTO = new BloodRequestDTO();
            bloodRequestDTO.BloodRequestId = bloodRequest.BloodRequestId;
            if (bloodRequest.BloodType == BloodType.AB_MINUS)
            {
                bloodRequestDTO.BloodType = "AB-";
            }
            else if (bloodRequest.BloodType == BloodType.AB_PLUS)
            {
                bloodRequestDTO.BloodType = "AB+";
            }
            else if (bloodRequest.BloodType == BloodType.A_MINUS)
            {
                bloodRequestDTO.BloodType = "A-";
            }
            else if (bloodRequest.BloodType == BloodType.A_PLUS)
            {
                bloodRequestDTO.BloodType = "A+";
            }
            else if (bloodRequest.BloodType == BloodType.B_MINUS)
            {
                bloodRequestDTO.BloodType = "B-";
            }
            else if (bloodRequest.BloodType == BloodType.B_PLUS)
            {
                bloodRequestDTO.BloodType = "B+";
            }
            else if (bloodRequest.BloodType == BloodType.O_MINUS)
            {
                bloodRequestDTO.BloodType = "O-";
            }
            else if (bloodRequest.BloodType == BloodType.O_PLUS)
            {
                bloodRequestDTO.BloodType = "O+";
            }

            bloodRequestDTO.ReasonForRequest = bloodRequest.ReasonForRequest;
            bloodRequestDTO.QuantityInLiters = bloodRequest.QuantityInLiters;
            bloodRequestDTO.FinalDate = bloodRequest.FinalDate;
            bloodRequestDTO.DoctorId = bloodRequest.DoctorId;

            return bloodRequestDTO;
        }

        public List<BloodRequestDTO> ToDTO(List<BloodRequest> bloodRequests)
        {
            List<BloodRequestDTO> bloodRequestDTOs = new List<BloodRequestDTO>();
            foreach (var bloodRequest in bloodRequests)
            {
                BloodRequestDTO bloodRequestDTO = new BloodRequestDTO();
                bloodRequestDTO.BloodRequestId = bloodRequest.BloodRequestId;
                if (bloodRequest.BloodType == BloodType.AB_MINUS)
                {
                    bloodRequestDTO.BloodType = "AB-";
                }
                else if (bloodRequest.BloodType == BloodType.AB_PLUS)
                {
                    bloodRequestDTO.BloodType = "AB+";
                }
                else if (bloodRequest.BloodType == BloodType.A_MINUS)
                {
                    bloodRequestDTO.BloodType = "A-";
                }
                else if (bloodRequest.BloodType == BloodType.A_PLUS)
                {
                    bloodRequestDTO.BloodType = "A+";
                }
                else if (bloodRequest.BloodType == BloodType.B_MINUS)
                {
                    bloodRequestDTO.BloodType = "B-";
                }
                else if (bloodRequest.BloodType == BloodType.B_PLUS)
                {
                    bloodRequestDTO.BloodType = "B+";
                }
                else if (bloodRequest.BloodType == BloodType.O_MINUS)
                {
                    bloodRequestDTO.BloodType = "O-";
                }
                else if (bloodRequest.BloodType == BloodType.O_PLUS)
                {
                    bloodRequestDTO.BloodType = "O+";
                }

                bloodRequestDTO.ReasonForRequest = bloodRequest.ReasonForRequest;
                bloodRequestDTO.QuantityInLiters = bloodRequest.QuantityInLiters;
                bloodRequestDTO.FinalDate = bloodRequest.FinalDate;
                bloodRequestDTO.DoctorId = bloodRequest.DoctorId;
                bloodRequestDTOs.Add(bloodRequestDTO); 

            }

            return bloodRequestDTOs;
        }

        public BloodRequest ToModel(BloodRequestDTO bloodRequestDTO)
        {
            BloodRequest bloodRequest = new BloodRequest();
            bloodRequest.BloodRequestId = bloodRequestDTO.BloodRequestId;
            if (bloodRequestDTO.BloodType.Equals("AB-"))
            {
                bloodRequest.BloodType = BloodType.AB_MINUS;
            }
            else if (bloodRequestDTO.BloodType.Equals("AB+"))
            {
                bloodRequest.BloodType = BloodType.AB_PLUS;
            }
            else if (bloodRequestDTO.BloodType.Equals("A-"))
            {
                bloodRequest.BloodType = BloodType.A_MINUS;
            }
            else if (bloodRequestDTO.BloodType.Equals("A+"))
            {
                bloodRequest.BloodType = BloodType.A_PLUS;
            }
            else if (bloodRequestDTO.BloodType.Equals("B-"))
            {
                bloodRequest.BloodType = BloodType.B_MINUS;
            }
            else if (bloodRequestDTO.BloodType.Equals("B+"))
            {
                bloodRequest.BloodType = BloodType.B_PLUS;
            }
            else if (bloodRequestDTO.BloodType.Equals("O-"))
            {
                bloodRequest.BloodType = BloodType.O_MINUS;
            }
            else if (bloodRequestDTO.BloodType.Equals("O+"))
            {
                bloodRequest.BloodType = BloodType.O_PLUS;
            }

            bloodRequest.ReasonForRequest = bloodRequestDTO.ReasonForRequest;
            bloodRequest.QuantityInLiters = bloodRequestDTO.QuantityInLiters;
            bloodRequest.FinalDate = bloodRequestDTO.FinalDate;
            bloodRequest.DoctorId = bloodRequestDTO.DoctorId;

            return bloodRequest;
        }

        public List<BloodRequest> ToModel(List<BloodRequestDTO> bloodRequestDTOs)
        {
            List<BloodRequest> bloodRequests = new List<BloodRequest>();
            foreach (var bloodRequestDTO in bloodRequestDTOs)
            {
                BloodRequest bloodRequest = new BloodRequest();
                bloodRequest.BloodRequestId = bloodRequestDTO.BloodRequestId;
                if (bloodRequestDTO.BloodType.Equals("AB-"))
                {
                    bloodRequest.BloodType = BloodType.AB_MINUS;
                }
                else if (bloodRequest.BloodType == BloodType.AB_PLUS)
                {
                    bloodRequest.BloodType = BloodType.AB_PLUS;
                }
                else if (bloodRequestDTO.BloodType.Equals("A-"))
                {
                    bloodRequest.BloodType = BloodType.A_MINUS;
                }
                else if (bloodRequestDTO.BloodType.Equals("A+"))
                {
                    bloodRequest.BloodType = BloodType.A_PLUS;
                }
                else if (bloodRequestDTO.BloodType.Equals("B-"))
                {
                    bloodRequest.BloodType = BloodType.B_MINUS;
                }
                else if (bloodRequestDTO.BloodType.Equals("B+"))
                {
                    bloodRequest.BloodType = BloodType.B_PLUS;
                }
                else if (bloodRequestDTO.BloodType.Equals("O-"))
                {
                    bloodRequest.BloodType = BloodType.O_MINUS;
                }
                else if (bloodRequestDTO.BloodType.Equals("O+"))
                {
                    bloodRequest.BloodType = BloodType.O_PLUS;
                }

                bloodRequest.ReasonForRequest = bloodRequestDTO.ReasonForRequest;
                bloodRequest.QuantityInLiters = bloodRequestDTO.QuantityInLiters;
                bloodRequest.FinalDate = bloodRequestDTO.FinalDate;
                bloodRequest.DoctorId = bloodRequestDTO.DoctorId;
                bloodRequests.Add(bloodRequest);
            }

            return bloodRequests;
        }

        public (Patient patient, User user, MedicalRecord medicalRecord) ToModels(PatientDTO patientDTO)
        {
            throw new NotImplementedException();
        }
    }
}
