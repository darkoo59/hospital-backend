using IntegrationLibrary.Features.EquipmentTenders.Domain;
using IntegrationLibrary.Features.EquipmentTenders.Enums;
using System;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.EquipmentTenders.DTO.UserDTO
{
    public class UserEquipmentTenderDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? ExpiresOn { get; set; }
        public string Description { get; set; }
        public TenderState State { get; set; }
        public UserEquipmentTenderDTO() { }
        public UserEquipmentTenderDTO(EquipmentTender tender)
        {
            Id = tender.Id;
            Title = tender.Title;
            ExpiresOn = tender.ExpiresOn;
            Description = tender.Description;
            State = tender.State;
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
