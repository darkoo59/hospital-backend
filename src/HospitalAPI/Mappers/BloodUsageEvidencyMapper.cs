using HospitalAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;

namespace HospitalAPI.Mappers
{
    public class BloodUsageEvidencyMapper : IGenericMapper<BloodUsageEvidency, BloodUsageEvidencyDTO>
    {
        public BloodUsageEvidencyDTO ToDTO(BloodUsageEvidency bloodUsageEvidency)
        {
            BloodUsageEvidencyDTO bloodUsageEvidencyDTO = new BloodUsageEvidencyDTO();
            bloodUsageEvidencyDTO.BloodUsageEvidencyId = bloodUsageEvidency.BloodUsageEvidencyId;
            if (bloodUsageEvidency.BloodType == BloodType.AB_MINUS)
            {
                bloodUsageEvidencyDTO.BloodType = "AB-";
            }
            else if (bloodUsageEvidency.BloodType == BloodType.AB_PLUS)
            {
                bloodUsageEvidencyDTO.BloodType = "AB+";
            }
            else if (bloodUsageEvidency.BloodType == BloodType.A_MINUS)
            {
                bloodUsageEvidencyDTO.BloodType = "A-";
            }
            else if (bloodUsageEvidency.BloodType == BloodType.A_PLUS)
            {
                bloodUsageEvidencyDTO.BloodType = "A+";
            }
            else if (bloodUsageEvidency.BloodType == BloodType.B_MINUS)
            {
                bloodUsageEvidencyDTO.BloodType = "B-";
            }
            else if (bloodUsageEvidency.BloodType == BloodType.B_PLUS)
            {
                bloodUsageEvidencyDTO.BloodType = "B+";
            }
            else if (bloodUsageEvidency.BloodType == BloodType.O_MINUS)
            {
                bloodUsageEvidencyDTO.BloodType = "O-";
            }
            else if (bloodUsageEvidency.BloodType == BloodType.O_PLUS)
            {
                bloodUsageEvidencyDTO.BloodType = "O+";
            }

            bloodUsageEvidencyDTO.QuantityUsedInMililiters = bloodUsageEvidency.QuantityUsedInMililiters;
            bloodUsageEvidencyDTO.ReasonForUsage = bloodUsageEvidency.ReasonForUsage;
            bloodUsageEvidencyDTO.DateOfUsage = bloodUsageEvidency.DateOfUsage;
            bloodUsageEvidencyDTO.DoctorId = bloodUsageEvidency.DoctorId;

            return bloodUsageEvidencyDTO;

        }

        public List<BloodUsageEvidencyDTO> ToDTO(List<BloodUsageEvidency> bloodUsageEvidencies)
        {
            List<BloodUsageEvidencyDTO> bloodUsageEvidencyDTOs = new List<BloodUsageEvidencyDTO>();

            foreach (var bloodUsageEvidency in bloodUsageEvidencies)
            {
                BloodUsageEvidencyDTO bloodUsageEvidencyDTO = new BloodUsageEvidencyDTO();
                bloodUsageEvidencyDTO.BloodUsageEvidencyId = bloodUsageEvidency.BloodUsageEvidencyId;
                if (bloodUsageEvidency.BloodType == BloodType.AB_MINUS)
                {
                    bloodUsageEvidencyDTO.BloodType = "AB-";
                }
                else if (bloodUsageEvidency.BloodType == BloodType.AB_PLUS)
                {
                    bloodUsageEvidencyDTO.BloodType = "AB+";
                }
                else if (bloodUsageEvidency.BloodType == BloodType.A_MINUS)
                {
                    bloodUsageEvidencyDTO.BloodType = "A-";
                }
                else if (bloodUsageEvidency.BloodType == BloodType.A_PLUS)
                {
                    bloodUsageEvidencyDTO.BloodType = "A+";
                }
                else if (bloodUsageEvidency.BloodType == BloodType.B_MINUS)
                {
                    bloodUsageEvidencyDTO.BloodType = "B-";
                }
                else if (bloodUsageEvidency.BloodType == BloodType.B_PLUS)
                {
                    bloodUsageEvidencyDTO.BloodType = "B+";
                }
                else if (bloodUsageEvidency.BloodType == BloodType.O_MINUS)
                {
                    bloodUsageEvidencyDTO.BloodType = "O-";
                }
                else if (bloodUsageEvidency.BloodType == BloodType.O_PLUS)
                {
                    bloodUsageEvidencyDTO.BloodType = "O+";
                }

                bloodUsageEvidencyDTO.QuantityUsedInMililiters = bloodUsageEvidency.QuantityUsedInMililiters;
                bloodUsageEvidencyDTO.ReasonForUsage = bloodUsageEvidency.ReasonForUsage;
                bloodUsageEvidencyDTO.DateOfUsage = bloodUsageEvidency.DateOfUsage;
                bloodUsageEvidencyDTO.DoctorId = bloodUsageEvidency.DoctorId;

                bloodUsageEvidencyDTOs.Add(bloodUsageEvidencyDTO);

            }

            return bloodUsageEvidencyDTOs;
        }

        public BloodUsageEvidency ToModel(BloodUsageEvidencyDTO bloodUsageEvidencyDTO)
        {
            BloodUsageEvidency bloodUsageEvidency = new BloodUsageEvidency();
            bloodUsageEvidency.BloodUsageEvidencyId = bloodUsageEvidencyDTO.BloodUsageEvidencyId;

            if (bloodUsageEvidencyDTO.BloodType.Equals("AB-"))
            {
                bloodUsageEvidency.BloodType = BloodType.AB_MINUS;
            }
            else if (bloodUsageEvidencyDTO.BloodType.Equals("AB+"))
            {
                bloodUsageEvidency.BloodType = BloodType.AB_PLUS;
            }
            else if (bloodUsageEvidencyDTO.BloodType.Equals("A-"))
            {
                bloodUsageEvidency.BloodType = BloodType.A_MINUS;
            }
            else if (bloodUsageEvidencyDTO.BloodType.Equals("A+"))
            {
                bloodUsageEvidency.BloodType = BloodType.A_PLUS;
            }
            else if (bloodUsageEvidencyDTO.BloodType.Equals("B-"))
            {
                bloodUsageEvidency.BloodType = BloodType.B_MINUS;
            }
            else if (bloodUsageEvidencyDTO.BloodType.Equals("B+"))
            {
                bloodUsageEvidency.BloodType = BloodType.B_PLUS;
            }
            else if (bloodUsageEvidencyDTO.BloodType.Equals("O-"))
            {
                bloodUsageEvidency.BloodType = BloodType.O_MINUS;
            }
            else if (bloodUsageEvidencyDTO.BloodType.Equals("O+"))
            {
                bloodUsageEvidency.BloodType = BloodType.O_PLUS;
            }

            bloodUsageEvidency.QuantityUsedInMililiters = bloodUsageEvidencyDTO.QuantityUsedInMililiters;
            bloodUsageEvidency.ReasonForUsage = bloodUsageEvidencyDTO.ReasonForUsage;
            bloodUsageEvidency.DateOfUsage = bloodUsageEvidencyDTO.DateOfUsage;
            bloodUsageEvidency.DoctorId = bloodUsageEvidencyDTO.DoctorId;

            return bloodUsageEvidency;

        }

        public List<BloodUsageEvidency> ToModel(List<BloodUsageEvidencyDTO> bloodUsageEvidencyDTOs)
        {
            List<BloodUsageEvidency> bloodUsageEvidencies = new List<BloodUsageEvidency>();

            foreach (var bloodUsageEvidencyDTO in bloodUsageEvidencyDTOs)
            {
                BloodUsageEvidency bloodUsageEvidency = new BloodUsageEvidency();
                bloodUsageEvidency.BloodUsageEvidencyId = bloodUsageEvidencyDTO.BloodUsageEvidencyId;

                if (bloodUsageEvidencyDTO.BloodType.Equals("AB-"))
                {
                    bloodUsageEvidency.BloodType = BloodType.AB_MINUS;
                }
                else if (bloodUsageEvidencyDTO.BloodType.Equals("AB+"))
                {
                    bloodUsageEvidency.BloodType = BloodType.AB_PLUS;
                }
                else if (bloodUsageEvidencyDTO.BloodType.Equals("A-"))
                {
                    bloodUsageEvidency.BloodType = BloodType.A_MINUS;
                }
                else if (bloodUsageEvidencyDTO.BloodType.Equals("A+"))
                {
                    bloodUsageEvidency.BloodType = BloodType.A_PLUS;
                }
                else if (bloodUsageEvidencyDTO.BloodType.Equals("B-"))
                {
                    bloodUsageEvidency.BloodType = BloodType.B_MINUS;
                }
                else if (bloodUsageEvidencyDTO.BloodType.Equals("B+"))
                {
                    bloodUsageEvidency.BloodType = BloodType.B_PLUS;
                }
                else if (bloodUsageEvidencyDTO.BloodType.Equals("O-"))
                {
                    bloodUsageEvidency.BloodType = BloodType.O_MINUS;
                }
                else if (bloodUsageEvidencyDTO.BloodType.Equals("O+"))
                {
                    bloodUsageEvidency.BloodType = BloodType.O_PLUS;
                }

                bloodUsageEvidency.QuantityUsedInMililiters = bloodUsageEvidencyDTO.QuantityUsedInMililiters;
                bloodUsageEvidency.ReasonForUsage = bloodUsageEvidencyDTO.ReasonForUsage;
                bloodUsageEvidency.DateOfUsage = bloodUsageEvidencyDTO.DateOfUsage;
                bloodUsageEvidency.DoctorId = bloodUsageEvidencyDTO.DoctorId;

                bloodUsageEvidencies.Add(bloodUsageEvidency);
            }
            return bloodUsageEvidencies;

        }
    }
}
