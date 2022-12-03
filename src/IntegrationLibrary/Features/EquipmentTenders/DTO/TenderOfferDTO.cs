using IntegrationLibrary.Features.EquipmentTenders.Domain;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.EquipmentTenders.DTO
{
    public class TenderOfferDTO
    {
        public int Id { get; set; }
        public double Cost { get; set; }
        public TenderRequirementDTO TenderRequirement { get; set; }

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
    }
}
