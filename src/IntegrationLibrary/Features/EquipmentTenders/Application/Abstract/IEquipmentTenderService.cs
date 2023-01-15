using IntegrationLibrary.Core.Utility;
using IntegrationLibrary.Features.EquipmentTenders.Domain;
using IntegrationLibrary.Features.EquipmentTenders.DTO.CreateDTO;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.EquipmentTenders.Application.Abstract
{
    public interface IEquipmentTenderService
    {
        ICollection<EquipmentTender> GetAll();
        void Create(CreateEquipmentTenderDTO dto);
        EquipmentTender GetById(int id);
        EquipmentTender GetByIdAndUser(int id, string email);
        void CreateApplication(string email, CreateTenderApplicationDTO dto);
        ICollection<TenderApplication> GetApplicationsByUser(string email);
        ICollection<EquipmentTender> GetAllByUser(string email);
        void DeleteApplicationByIdAndUser(int id, string email);
        TenderApplication GetApplicationById(int id);
        EquipmentTender GetTenderWithApplicationsById(int id);
        void SetWinner(int applicationId);
        void ConfirmWinner(int applicationId, string email);
        void DeclineWinner(int applicationId, string email);
        string GenerateAndUploadPdf(DateRange dateRange);
    }
}
