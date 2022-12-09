using System.Collections.Generic;

namespace IntegrationLibrary.Features.EquipmentTenders.DTO.CreateDTO
{
    public class CreateTenderApplicationDTO
    {
        public string Note { get; set; }
        public int EquipmentTenderId { get; set; }
        public ICollection<CreateTenderOfferDTO> TenderOffers { get; set; }

        public CreateTenderApplicationDTO() { }
    }
}
