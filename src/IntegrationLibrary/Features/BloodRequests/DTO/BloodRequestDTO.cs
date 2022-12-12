using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Features.Blood.Enums;
using IntegrationLibrary.Features.BloodRequests.Enums;
using IntegrationLibrary.Features.BloodRequests.Model;
using System;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.BloodRequests.DTO
{
    public class BloodRequestDTO
    {
        public int Id { get; set; }
        public string BloodType { get; set; }
        public double QuantityInLiters { get; set; }
        public string ReasonForRequest { get; set; }
        public DateTime FinalDate { get; set; }
        public Doctor Doctor { get; set; }
        public BloodRequestState State { get; set; }
        public string ReasonForAdjustment{ get; set; }
        public bool Urgent { get; set; }

        public BloodRequestDTO() { }

        public BloodRequestDTO(BloodRequest br)
        {
            Id = br.Id;
            BloodType = BloodTypeToString(br.BloodType);
            QuantityInLiters = br.QuantityInLiters;
            ReasonForRequest = br.ReasonForRequest;
            FinalDate = br.FinalDate;
            State = br.State;
            ReasonForAdjustment = br.ReasonForAdjustment;
            Urgent = false;
        }

        public static List<BloodRequestDTO> ToDTOList(List<BloodRequest> brs)
        {
            List<BloodRequestDTO> temp = new();
            foreach(BloodRequest b in brs)
            {
                temp.Add(new BloodRequestDTO(b));
            }
            return temp;
        }

        public bool Equals(BloodRequestDTO obj)
        {
            if(obj != null)
            {
                if (obj.Id != Id) return false; 
                if (obj.BloodType != BloodType) return false; 
                if (obj.QuantityInLiters != QuantityInLiters) return false; 
                if (!obj.ReasonForRequest.Equals(ReasonForRequest)) return false;
                if (obj.FinalDate != FinalDate) return false;
                return true;
            }
            return base.Equals(obj);
        }

        public static string BloodTypeToString(BloodType bt)
        {
            string[] arr = { "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-"};
            for(int i = 0; i < arr.Length; i++)
            {
                if (bt == (BloodType)i) return arr[i];
            }
            return "NONE";
        }
    }
}
