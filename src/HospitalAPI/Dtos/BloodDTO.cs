using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dtos
{
    public class BloodDTO
    {
        public int BloodId { get; set; }
        public string BloodType { get; set; }
        public double QuantityInLiters { get; set; }

        public BloodDTO()
        {
        }

        public BloodDTO(int bloodId, string bloodType, double quantityInLiters)
        {
            BloodId = bloodId;
            BloodType = bloodType;
            QuantityInLiters = quantityInLiters;
        }

    }
}
