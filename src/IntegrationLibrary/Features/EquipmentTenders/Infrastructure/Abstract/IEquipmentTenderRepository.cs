using IntegrationLibrary.Core.Utility;
using IntegrationLibrary.Features.EquipmentTenders.Domain;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.EquipmentTenders.Infrastructure.Abstract
{
    public interface IEquipmentTenderRepository
    {
        void Create(EquipmentTender tender);
        ICollection<EquipmentTender> GetAll();
        EquipmentTender GetById(int id);
        EquipmentTender GetByIdAndUser(int id, int userId);
        void Update(EquipmentTender tender);
        void Update(TenderApplication application);
        ICollection<TenderApplication> GetTenderApplicationsByUser(int userId);
        ICollection<EquipmentTender> GetAllByUser(int userId);
        void DeleteApplicationByIdAndUser(int id, int userId);
        TenderApplication GetApplicationById(int id);
        EquipmentTender GetTenderWithApplicationsById(int id);
        ICollection<TenderApplication> GetFinishedApplications(DateRange dr);
        ICollection<TenderApplication> GetAllUsersByTenderEquipmentId(int id);
    }
}
