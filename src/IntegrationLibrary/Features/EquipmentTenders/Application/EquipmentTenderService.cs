using IntegrationLibrary.Features.BloodBank.Model;
using IntegrationLibrary.Features.BloodBank.Service;
using IntegrationLibrary.Features.EquipmentTenders.Application.Abstract;
using IntegrationLibrary.Features.EquipmentTenders.Domain;
using IntegrationLibrary.Features.EquipmentTenders.DTO;
using IntegrationLibrary.Features.EquipmentTenders.DTO.CreateDTO;
using IntegrationLibrary.Features.EquipmentTenders.Infrastructure.Abstract;
using System;
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

        public EquipmentTender GetByIdAndUser(int id, string email)
        {
            User user = _userService.GetBy(email);
            EquipmentTender temp = _repository.GetByIdAndUser(id, user.Id);
            if (temp == null) throw new Exception("Blood bank has already made application for requested tender.");
            return temp;
        }

        public void CreateApplication(string email, CreateTenderApplicationDTO dto)
        {
            User user = _userService.GetBy(email);
            EquipmentTender et = _repository.GetByIdAndUser(dto.EquipmentTenderId, user.Id);
            if (et == null) throw new Exception("Blood bank has already made application for requested tender.");

            List<TenderOffer> temp = new();
            foreach (CreateTenderOfferDTO offerDTO in dto.TenderOffers)
            {
                temp.Add(new TenderOffer(offerDTO.Cost, offerDTO.TenderRequirementId));
            }
            TenderApplication ta = new(dto.Note, dto.EquipmentTenderId, user.Id, temp);

            et.AddApplication(ta);
            _repository.Update(et);
        }

        public ICollection<TenderApplication> GetApplicationsByUser(string email)
        {
            User user = _userService.GetBy(email);

            return _repository.GetTenderApplicationsByUser(user.Id);
        }

        public ICollection<EquipmentTender> GetAllByUser(string email)
        {
            User user = _userService.GetBy(email);

            return _repository.GetAllByUser(user.Id);
        }

        public void DeleteApplicationByIdAndUser(int id, string email)
        {
            User user = _userService.GetBy(email);

            _repository.DeleteApplicationByIdAndUser(id, user.Id);
        }

        public TenderApplication GetApplicationById(int id)
        {
            return _repository.GetApplicationById(id);
        }

        public EquipmentTender GetTenderWithApplicationsById(int id)
        {
            return _repository.GetTenderWithApplicationsById(id);
        }
    }
}
