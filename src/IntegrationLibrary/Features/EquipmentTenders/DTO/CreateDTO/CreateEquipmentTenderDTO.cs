using System;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.EquipmentTenders.DTO.CreateDTO
{
    public class CreateEquipmentTenderDTO
    {
        public string Title { get; set; }
        public DateTime? ExpiresOn { get; set; }
        public string Description { get; set; }
        public ICollection<TenderRequirementDTO> Requirements { get; set; }
    }
}
