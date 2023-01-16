using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dtos
{
    public class TenderRequirementDTO
    {
        public int Id { get; set; }
        public BloodType Type { get; set; }
        public double Amount { get; set; }
      //  public TenderRequirementDTO() { }
        
        /*
        public TenderRequirementDTO(TenderRequirement tr)
        {
            if (tr == null) return;
            Id = tr.Id;
            Type = tr.BloodType;
            Amount = tr.Amount;
        }

        public static List<TenderRequirementDTO> ToDTOList(ICollection<TenderRequirement> list)
        {
            List<TenderRequirementDTO> temp = new();
            foreach (TenderRequirement tender in list)
            {
                temp.Add(new TenderRequirementDTO(tender));
            }
            return temp;
        }

        */
    }
}
