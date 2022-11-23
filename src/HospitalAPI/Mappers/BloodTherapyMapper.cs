using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalAPI.Dtos;
using HospitalLibrary.Core.Model;

namespace HospitalAPI.Mappers
{
    public class BloodTherapyMapper : IGenericMapper<BloodTherapy, BloodTherapyDTO>
    {
        public BloodTherapyDTO ToDTO(BloodTherapy bloodTherapy)
        {
            BloodTherapyDTO bloodTherapyDTO = new BloodTherapyDTO();
            bloodTherapyDTO.BloodTherapyId = bloodTherapy.BloodTherapyId;
            if (bloodTherapy.BloodType == BloodType.AB_MINUS)
            {
                bloodTherapyDTO.BloodType = "AB-";
            }
            else if (bloodTherapy.BloodType == BloodType.AB_PLUS)
            {
                bloodTherapyDTO.BloodType = "AB+";
            }
            else if (bloodTherapy.BloodType == BloodType.A_MINUS)
            {
                bloodTherapyDTO.BloodType = "A-";
            }
            else if (bloodTherapy.BloodType == BloodType.A_PLUS)
            {
                bloodTherapyDTO.BloodType = "A+";
            }
            else if (bloodTherapy.BloodType == BloodType.B_MINUS)
            {
                bloodTherapyDTO.BloodType = "B-";
            }
            else if (bloodTherapy.BloodType == BloodType.B_PLUS)
            {
                bloodTherapyDTO.BloodType = "B+";
            }
            else if (bloodTherapy.BloodType == BloodType.O_MINUS)
            {
                bloodTherapyDTO.BloodType = "O-";
            }
            else if (bloodTherapy.BloodType == BloodType.O_PLUS)
            {
                bloodTherapyDTO.BloodType = "O+";
            }
            bloodTherapyDTO.QuantityInLiters = bloodTherapy.QuantityInLiters;
            bloodTherapyDTO.Start = bloodTherapy.Start;
            bloodTherapyDTO.End = bloodTherapy.End;
            return bloodTherapyDTO;
        }

        public List<BloodTherapyDTO> ToDTO(List<BloodTherapy> bloodTherapies)
        {
            List<BloodTherapyDTO> bloodTherapyDTOs = new List<BloodTherapyDTO>();
            foreach (var bloodTherapy in bloodTherapies)
            {
                BloodTherapyDTO bloodTherapyDTO = new BloodTherapyDTO();
                bloodTherapyDTO.BloodTherapyId = bloodTherapy.BloodTherapyId;
                if (bloodTherapy.BloodType == BloodType.AB_MINUS)
                {
                    bloodTherapyDTO.BloodType = "AB-";
                }
                else if (bloodTherapy.BloodType == BloodType.AB_PLUS)
                {
                    bloodTherapyDTO.BloodType = "AB+";
                }
                else if (bloodTherapy.BloodType == BloodType.A_MINUS)
                {
                    bloodTherapyDTO.BloodType = "A-";
                }
                else if (bloodTherapy.BloodType == BloodType.A_PLUS)
                {
                    bloodTherapyDTO.BloodType = "A+";
                }
                else if (bloodTherapy.BloodType == BloodType.B_MINUS)
                {
                    bloodTherapyDTO.BloodType = "B-";
                }
                else if (bloodTherapy.BloodType == BloodType.B_PLUS)
                {
                    bloodTherapyDTO.BloodType = "B+";
                }
                else if (bloodTherapy.BloodType == BloodType.O_MINUS)
                {
                    bloodTherapyDTO.BloodType = "O-";
                }
                else if (bloodTherapy.BloodType == BloodType.O_PLUS)
                {
                    bloodTherapyDTO.BloodType = "O+";
                }
                bloodTherapyDTO.QuantityInLiters = bloodTherapy.QuantityInLiters;
                bloodTherapyDTO.Start = bloodTherapy.Start;
                bloodTherapyDTO.End = bloodTherapy.End;
                bloodTherapyDTOs.Add(bloodTherapyDTO);
            }

            return bloodTherapyDTOs;
        }

        public BloodTherapy ToModel(BloodTherapyDTO bloodTherapyDTO)
        {
            BloodTherapy bloodTherapy = new BloodTherapy();
            bloodTherapy.BloodTherapyId = bloodTherapyDTO.BloodTherapyId;
            if (bloodTherapyDTO.BloodType.Equals("AB-"))
            {
                bloodTherapy.BloodType = BloodType.AB_MINUS;
            }
            else if (bloodTherapyDTO.BloodType.Equals(BloodType.AB_PLUS))
            {
                bloodTherapy.BloodType = BloodType.AB_PLUS;
            }
            else if (bloodTherapyDTO.BloodType.Equals("A-"))
            {
                bloodTherapy.BloodType = BloodType.A_MINUS;
            }
            else if (bloodTherapyDTO.BloodType.Equals("A+"))
            {
                bloodTherapy.BloodType = BloodType.A_PLUS;
            }
            else if (bloodTherapyDTO.BloodType.Equals("B-"))
            {
                bloodTherapy.BloodType = BloodType.B_MINUS;
            }
            else if (bloodTherapyDTO.BloodType.Equals("B+"))
            {
                bloodTherapy.BloodType = BloodType.B_PLUS;
            }
            else if (bloodTherapyDTO.BloodType.Equals("O-"))
            {
                bloodTherapy.BloodType = BloodType.O_MINUS;
            }
            else if (bloodTherapyDTO.BloodType.Equals("O+"))
            {
                bloodTherapy.BloodType = BloodType.O_PLUS;
            }
            bloodTherapy.QuantityInLiters = bloodTherapyDTO.QuantityInLiters;
            bloodTherapy.Start = bloodTherapyDTO.Start;
            bloodTherapy.End = bloodTherapyDTO.End;
            return bloodTherapy;
        }

        public List<BloodTherapy> ToModel(List<BloodTherapyDTO> bloodTherapyDTOs)
        {
            List<BloodTherapy> bloodTherapies = new List<BloodTherapy>();
            foreach (var bloodTherapyDTO in bloodTherapyDTOs)
            {
                BloodTherapy bloodTherapy = new BloodTherapy();
                bloodTherapy.BloodTherapyId = bloodTherapyDTO.BloodTherapyId;
                if (bloodTherapyDTO.BloodType.Equals("AB-"))
                {
                    bloodTherapy.BloodType = BloodType.AB_MINUS;
                }
                else if (bloodTherapyDTO.BloodType.Equals(BloodType.AB_PLUS))
                {
                    bloodTherapy.BloodType = BloodType.AB_PLUS;
                }
                else if (bloodTherapyDTO.BloodType.Equals("A-"))
                {
                    bloodTherapy.BloodType = BloodType.A_MINUS;
                }
                else if (bloodTherapyDTO.BloodType.Equals("A+"))
                {
                    bloodTherapy.BloodType = BloodType.A_PLUS;
                }
                else if (bloodTherapyDTO.BloodType.Equals("B-"))
                {
                    bloodTherapy.BloodType = BloodType.B_MINUS;
                }
                else if (bloodTherapyDTO.BloodType.Equals("B+"))
                {
                    bloodTherapy.BloodType = BloodType.B_PLUS;
                }
                else if (bloodTherapyDTO.BloodType.Equals("O-"))
                {
                    bloodTherapy.BloodType = BloodType.O_MINUS;
                }
                else if (bloodTherapyDTO.BloodType.Equals("O+"))
                {
                    bloodTherapy.BloodType = BloodType.O_PLUS;
                }
                bloodTherapy.QuantityInLiters = bloodTherapyDTO.QuantityInLiters;
                bloodTherapy.Start = bloodTherapyDTO.Start;
                bloodTherapy.End = bloodTherapyDTO.End;
                bloodTherapies.Add(bloodTherapy);
            }

            return bloodTherapies;
        }
    }
}
