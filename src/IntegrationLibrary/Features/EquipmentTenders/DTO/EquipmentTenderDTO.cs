using IntegrationLibrary.Features.EquipmentTenders.Domain;
using IntegrationLibrary.Features.EquipmentTenders.Enums;
using System;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.EquipmentTenders.DTO
{
    public class EquipmentTenderDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? ExpiresOn { get; set; }
        public string Description { get; set; }
        public ICollection<TenderRequirementDTO> Requirements { get; set; }
        public TenderState State { get; set; }
        public EquipmentTenderDTO() { }
        public EquipmentTenderDTO(EquipmentTender tender)
        {
            Id = tender.Id;
            Title = tender.Title;
            ExpiresOn = tender.ExpiresOn;
            Description = tender.Description;
            State = tender.State;
            if(tender.TenderRequirements != null)
                Requirements = new List<TenderRequirementDTO>(TenderRequirementDTO.ToDTOList(tender.TenderRequirements));
        }

        public static List<EquipmentTenderDTO> ToDTOList(ICollection<EquipmentTender> list)
        {
            List<EquipmentTenderDTO> temp = new();
            foreach (EquipmentTender tender in list)
            {
                temp.Add(new EquipmentTenderDTO(tender));
            }
            return temp;
        }
    }
}
