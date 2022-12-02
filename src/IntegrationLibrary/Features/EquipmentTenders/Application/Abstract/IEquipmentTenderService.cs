using IntegrationLibrary.Features.EquipmentTenders.Domain;
using IntegrationLibrary.Features.EquipmentTenders.DTO;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.EquipmentTenders.Application.Abstract
{
    public interface IEquipmentTenderService
    {
        ICollection<EquipmentTender> GetAll();
        void Create(CreateEquipmentTenderDTO dto);
        EquipmentTender GetById(int id);
        void CreateApplication(string email, CreateTenderApplicationDTO dto);
    }
}
