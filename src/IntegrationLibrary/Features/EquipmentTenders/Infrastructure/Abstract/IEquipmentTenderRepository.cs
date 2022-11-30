using IntegrationLibrary.Features.EquipmentTenders.Domain;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.EquipmentTenders.Infrastructure.Abstract
{
    public interface IEquipmentTenderRepository
    {
        void Create(EquipmentTender tender);
        ICollection<EquipmentTender> GetAll();
        EquipmentTender GetById(int id);
    }
}
