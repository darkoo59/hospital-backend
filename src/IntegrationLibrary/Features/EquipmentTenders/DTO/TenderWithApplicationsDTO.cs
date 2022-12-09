using IntegrationLibrary.Features.EquipmentTenders.Domain;
using IntegrationLibrary.Features.EquipmentTenders.Enums;
using System;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.EquipmentTenders.DTO
{
    public class TenderWithApplicationsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? ExpiresOn { get; set; }
        public string Description { get; set; }
        public TenderState State { get; set; }
        public ICollection<TenderApplicationDTO> TenderApplications { get; private set; }

        public TenderWithApplicationsDTO(EquipmentTender tender)
        {
            Id = tender.Id;
            Title = tender.Title;
            ExpiresOn = tender.ExpiresOn;
            Description = tender.Description;
            State = tender.State;

            TenderApplications = TenderApplicationDTO.ToDTOList(tender.TenderApplications);
        }
    }
}
