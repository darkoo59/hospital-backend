using IntegrationLibrary.Features.EquipmentTenders.Application.Abstract;
using IntegrationLibrary.Features.EquipmentTenders.Domain;
using IntegrationLibrary.Features.EquipmentTenders.DTO;
using IntegrationLibrary.Features.EquipmentTenders.Infrastructure.Abstract;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.EquipmentTenders.Application
{
    public class EquipmentTenderService : IEquipmentTenderService
    {
        private readonly IEquipmentTenderRepository _repository;
        public EquipmentTenderService(IEquipmentTenderRepository repository)
        {
            _repository = repository;
        }

        public void Create(CreateEquipmentTenderDTO dto)
        {
            ICollection<TenderRequirement> temp = TenderRequirementDTO.FromDTOList(dto.Requirements);
            EquipmentTender et = new(dto.Title, dto.ExpiresOn, dto.Description, temp);
            _repository.Create(et);
        }

        public ICollection<EquipmentTender> GetAll()
        {
            return _repository.GetAll();
        }

        public EquipmentTender GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
