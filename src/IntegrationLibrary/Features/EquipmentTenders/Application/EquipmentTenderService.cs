using IntegrationLibrary.Features.BloodBank.Model;
using IntegrationLibrary.Features.BloodBank.Service;
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
        private readonly IUserService _userService;
        public EquipmentTenderService(IEquipmentTenderRepository repository, IUserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        public void Create(CreateEquipmentTenderDTO dto)
        {
            List<TenderRequirement> temp = new();
            foreach (TenderRequirementDTO req in dto.Requirements)
            {
                temp.Add(new TenderRequirement(req.Name, req.Amount));
            }
            
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

        public void CreateApplication(string email, CreateTenderApplicationDTO dto)
        {
            User user = _userService.GetBy(email);

            List<TenderOffer> temp = new();
            foreach (CreateTenderOfferDTO offerDTO in dto.TenderOffers)
            {
                temp.Add(new TenderOffer(offerDTO.Cost, offerDTO.TenderRequirementId));
            }
            TenderApplication ta = new(dto.Note, dto.EquipmentTenderId, user.Id, temp);

            EquipmentTender et = _repository.GetById(dto.EquipmentTenderId);
            et.AddApplication(ta);
            _repository.Update(et);
        }
    }
}
