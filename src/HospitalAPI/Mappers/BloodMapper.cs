using HospitalAPI.Dtos;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Mappers
{
    public class BloodMapper : IGenericMapper<Blood, BloodDTO>
    {
        public BloodDTO ToDTO(Blood blood)
        {
            BloodDTO bloodDTO = new BloodDTO();
            bloodDTO.BloodId = blood.BloodId;
            if (blood.BloodType == BloodType.AB_MINUS)
            {
                bloodDTO.BloodType = "AB-";
            }
            else if (blood.BloodType == BloodType.AB_PLUS)
            {
                bloodDTO.BloodType = "AB+";
            }
            else if (blood.BloodType == BloodType.A_MINUS)
            {
                bloodDTO.BloodType = "A-";
            }
            else if (blood.BloodType == BloodType.A_PLUS)
            {
                bloodDTO.BloodType = "A+";
            }
            else if (blood.BloodType == BloodType.B_MINUS)
            {
                bloodDTO.BloodType = "B-";
            }
            else if (blood.BloodType == BloodType.B_PLUS)
            {
                bloodDTO.BloodType = "B+";
            }
            else if (blood.BloodType == BloodType.O_MINUS)
            {
                bloodDTO.BloodType = "O-";
            }
            else if (blood.BloodType == BloodType.O_PLUS)
            {
                bloodDTO.BloodType = "O+";
            }

            bloodDTO.QuantityInLiters = blood.QuantityInLiters;

            return bloodDTO;
        }

        public List<BloodDTO> ToDTO(List<Blood> bloods)
        {
            List<BloodDTO> bloodDTOs = new List<BloodDTO>();
            foreach (var blood in bloods)
            {
                BloodDTO bloodDTO = new BloodDTO();
                bloodDTO.BloodId = blood.BloodId;
                if (blood.BloodType == BloodType.AB_MINUS)
                {
                    bloodDTO.BloodType = "AB-";
                }
                else if (blood.BloodType == BloodType.AB_PLUS)
                {
                    bloodDTO.BloodType = "AB+";
                }
                else if (blood.BloodType == BloodType.A_MINUS)
                {
                    bloodDTO.BloodType = "A-";
                }
                else if (blood.BloodType == BloodType.A_PLUS)
                {
                    bloodDTO.BloodType = "A+";
                }
                else if (blood.BloodType == BloodType.B_MINUS)
                {
                    bloodDTO.BloodType = "B-";
                }
                else if (blood.BloodType == BloodType.B_PLUS)
                {
                    bloodDTO.BloodType = "B+";
                }
                else if (blood.BloodType == BloodType.O_MINUS)
                {
                    bloodDTO.BloodType = "O-";
                }
                else if (blood.BloodType == BloodType.O_PLUS)
                {
                    bloodDTO.BloodType = "O+";
                }

                bloodDTO.QuantityInLiters = blood.QuantityInLiters;
                bloodDTOs.Add(bloodDTO);
            }

            return bloodDTOs;
        }

        public Blood ToModel(BloodDTO bloodDTO)
        {
            Blood blood = new Blood();
            blood.BloodId = bloodDTO.BloodId;
            if (bloodDTO.BloodType.Equals("AB-"))
            {
                blood.BloodType = BloodType.AB_MINUS;
            }
            else if (bloodDTO.BloodType.Equals("AB+"))
            {
                blood.BloodType = BloodType.AB_PLUS;
            }
            else if (bloodDTO.BloodType.Equals("A-"))
            {
                blood.BloodType = BloodType.A_MINUS;
            }
            else if (bloodDTO.BloodType.Equals("A+"))
            {
                blood.BloodType = BloodType.A_PLUS;
            }
            else if (bloodDTO.BloodType.Equals("B-"))
            {
                blood.BloodType = BloodType.B_MINUS;
            }
            else if (bloodDTO.BloodType.Equals("B+"))
            {
                blood.BloodType = BloodType.B_PLUS;
            }
            else if (bloodDTO.BloodType.Equals("O-"))
            {
                blood.BloodType = BloodType.O_MINUS;
            }
            else if (bloodDTO.BloodType.Equals("O+"))
            {
                blood.BloodType = BloodType.O_PLUS;
            }

            blood.QuantityInLiters = bloodDTO.QuantityInLiters;

            return blood;
        }

        public List<Blood> ToModel(List<BloodDTO> bloodDTOs)
        {
            List<Blood> bloods = new List<Blood>();
            foreach (var bloodDTO in bloodDTOs)
            {
                Blood blood = new Blood();
                blood.BloodId = bloodDTO.BloodId;
                if (bloodDTO.BloodType.Equals("AB-"))
                {
                    blood.BloodType = BloodType.AB_MINUS;
                }
                else if (bloodDTO.BloodType.Equals(BloodType.AB_PLUS))
                {
                    blood.BloodType = BloodType.AB_PLUS;
                }
                else if (bloodDTO.BloodType.Equals("A-"))
                {
                    blood.BloodType = BloodType.A_MINUS;
                }
                else if (bloodDTO.BloodType.Equals("A+"))
                {
                    blood.BloodType = BloodType.A_PLUS;
                }
                else if (bloodDTO.BloodType.Equals("B-"))
                {
                    blood.BloodType = BloodType.B_MINUS;
                }
                else if (bloodDTO.BloodType.Equals("B+"))
                {
                    blood.BloodType = BloodType.B_PLUS;
                }
                else if (bloodDTO.BloodType.Equals("O-"))
                {
                    blood.BloodType = BloodType.O_MINUS;
                }
                else if (bloodDTO.BloodType.Equals("O+"))
                {
                    blood.BloodType = BloodType.O_PLUS;
                }

                blood.QuantityInLiters = bloodDTO.QuantityInLiters;

                bloods.Add(blood);
            }
            return bloods;
        }
    }
}
