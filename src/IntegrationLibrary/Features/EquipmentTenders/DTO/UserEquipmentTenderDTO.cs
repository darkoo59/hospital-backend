using IntegrationLibrary.Features.EquipmentTenders.Domain;
using System;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.EquipmentTenders.DTO
{
    public class UserEquipmentTenderDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? ExpiresOn { get; set; }
        public string Description { get; set; }
        public UserEquipmentTenderDTO() { }
        public UserEquipmentTenderDTO(EquipmentTender tender)
        {
            Id = tender.Id;
            Title = tender.Title;
            ExpiresOn = tender.ExpiresOn;
            Description = tender.Description;
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
