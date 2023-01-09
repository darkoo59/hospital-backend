using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dtos
{
    public class TenderOfferDTO
    {
        public int Id { get; set; }
        public double Cost { get; set; }
        public TenderRequirementDTO TenderRequirement { get; set; }


        /*
        public TenderOfferDTO(TenderOffer to)
        {
            Id = to.Id;
            Cost = to.Money.Amount;
            TenderRequirement = new TenderRequirementDTO(to.TenderRequirement);
        }

        public static ICollection<TenderOfferDTO> ToDTOList(ICollection<TenderOffer> tos)
        {
            List<TenderOfferDTO> dtos = new();
            foreach (TenderOffer to in tos)
            {
                dtos.Add(new TenderOfferDTO(to));
            }
            return dtos;
        }


        */
    }
}
