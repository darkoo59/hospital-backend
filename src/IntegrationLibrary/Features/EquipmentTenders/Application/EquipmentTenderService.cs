using IntegrationLibrary.Features.Blood.DTO;
using IntegrationLibrary.Features.BloodBank;
using IntegrationLibrary.Features.BloodBank.Model;
using IntegrationLibrary.Features.BloodBank.Service;
using IntegrationLibrary.Features.EquipmentTenders.Application.Abstract;
using IntegrationLibrary.Features.EquipmentTenders.Domain;
using IntegrationLibrary.Features.EquipmentTenders.DTO;
using IntegrationLibrary.Features.EquipmentTenders.DTO.CreateDTO;
using IntegrationLibrary.Features.EquipmentTenders.Enums;
using IntegrationLibrary.Features.EquipmentTenders.Infrastructure.Abstract;
using IntegrationLibrary.HospitalService;
using System;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.EquipmentTenders.Application
{
    public class EquipmentTenderService : IEquipmentTenderService
    {
        private readonly IEquipmentTenderRepository _repository;
        private readonly IUserService _userService;
        private readonly IHospitalService _hospitalService;
        private readonly IBloodBankService _bloodBankService;
        public EquipmentTenderService(IEquipmentTenderRepository repository, IUserService userService, IHospitalService hospitalService, IBloodBankService bloodBankService)
        {
            _repository = repository;
            _userService = userService;
            _hospitalService = hospitalService;
            _bloodBankService = bloodBankService;
        }

        public void Create(CreateEquipmentTenderDTO dto)
        {
            List<TenderRequirement> temp = new();
            foreach (TenderRequirementDTO req in dto.Requirements)
            {
                temp.Add(new TenderRequirement(req.Type, req.Amount));
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
            if (et.State == TenderState.CLOSED) throw new Exception("Tender has already been concluded.");

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

        public void SetWinner(int applicationId)
        {
            TenderApplication ta = _repository.GetApplicationById(applicationId);
            if (ta == null) throw new Exception("Application has not been found.");
            if (ta.EquipmentTender.State != TenderState.OPEN) throw new Exception("Tender is not open");

            ta.EquipmentTender.SetState(TenderState.PENDING);
            ta.SetHasWon(true);

            _repository.Update(ta);
        }

        public void ConfirmWinner(int applicationId, string email)
        {
            User user = _userService.GetBy(email);

            TenderApplication ta = _repository.GetApplicationById(applicationId);
            if (ta == null) throw new Exception("Application has not been found.");
            if (ta.User.Id != user.Id) throw new Exception("Invalid access");
            if (!ta.HasWon) throw new Exception("Some error has occurred");

            ta.EquipmentTender.SetState(TenderState.CLOSED);

            List<BloodDTO> bloodDTOs = new();
            foreach (TenderOffer offer in ta.TenderOffers)
            {
                BloodDTO dto = new()
                {
                    Type = offer.TenderRequirement.BloodType,
                    Amount = offer.TenderRequirement.Amount
                };
                bloodDTOs.Add(dto);
            }

            _ = _bloodBankService.ConfirmTender(user, bloodDTOs).Result;
            _ = _hospitalService.UpdateBlood(bloodDTOs).Result;

            _repository.Update(ta);
        }

        public void DeclineWinner(int applicationId, string email)
        {
            User user = _userService.GetBy(email);

            TenderApplication ta = _repository.GetApplicationById(applicationId);
            if (ta == null) throw new Exception("Application has not been found.");
            if (ta.User.Id != user.Id) throw new Exception("Invalid access");
            if (!ta.HasWon) throw new Exception("Some error has occurred");

            ta.EquipmentTender.SetState(TenderState.OPEN);
            ta.SetHasWon(false);

            _repository.Update(ta);
        }
    }
}
