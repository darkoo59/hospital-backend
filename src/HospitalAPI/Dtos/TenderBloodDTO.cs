using HospitalLibrary.Core.Model;
using System.Collections.Generic;

namespace HospitalAPI.Dtos
{
    public class TenderBloodDTO
    {
        public BloodType Type { get; set; }
        public double Amount { get; set; }

        public TenderBloodDTO() { }

        public static ICollection<Blood> FromDTOList(ICollection<TenderBloodDTO> dtos)
        {
            List<Blood> temp = new();
            foreach (TenderBloodDTO dto in dtos)
            {
                Blood b = new()
                {
                    BloodType = dto.Type,
                    QuantityInLiters = dto.Amount
                };
                temp.Add(b);
            }
            return temp;
        }
    }
}
