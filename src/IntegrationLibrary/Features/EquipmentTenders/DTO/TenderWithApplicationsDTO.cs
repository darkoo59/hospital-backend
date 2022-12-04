using IntegrationLibrary.Features.EquipmentTenders.Domain;
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
        public ICollection<TenderApplicationDTO> TenderApplications { get; private set; }

        public TenderWithApplicationsDTO(EquipmentTender tender)
        {
            Id = tender.Id;
            Title = tender.Title;
            ExpiresOn = tender.ExpiresOn;
            Description = tender.Description;

            TenderApplications = TenderApplicationDTO.ToDTOList(tender.TenderApplications);
        }
    }
}
