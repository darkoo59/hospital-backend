using IntegrationLibrary.Core.Model;
﻿using Gehtsoft.PDFFlow.Builder;
using IntegrationLibrary.Core.Utility;
using IntegrationLibrary.Features.Blood.DTO;
using IntegrationLibrary.Features.Blood.Enums;
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
using System.Linq;
using System.IO;

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
            List<User> tenderParticipants = new List<User>();
            foreach (TenderApplication taIter in _repository.GetAllUsersByTenderEquipmentId(applicationId))
            {
                tenderParticipants.Add(taIter.User);
            }
            if (ta == null) throw new Exception("Application has not been found.");
            if (ta.User.Id != user.Id) throw new Exception("Invalid access");
            if (!ta.HasWon) throw new Exception("Some error has occurred");

            SendEmailToWinner(email, ta);
            foreach (User userIter in tenderParticipants)
            {
                if (!userIter.Email.Equals(email))
                    SendEmailToOtherParticipants(userIter.Email, ta);
            }
            ta.EquipmentTender.SetState(TenderState.CLOSED);
            ta.SetDate(DateTime.Now);

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

        public void SendEmailToWinner(string email, TenderApplication ta)
        {
            foreach(TenderOffer to in ta.TenderOffers)
            {

                MailContent content = new MailContent()
                {
                    ToEmail = email,
                    Subject = "Hospital tender ended",
                    Body = "    Congratulations, you have successfully won our equipment tender. Detailed informations " +
                    "about tender are in the continuation of this email. Blood amount : " + to.TenderRequirement.Amount + " ." +
                    "Blood type :" + to.TenderRequirement.BloodType.ToString() + ".",
                    Attachments = null
                };
                _bloodBankService.SendEmail(content);
                break;
            }
        }

        public void SendEmailToOtherParticipants(string email, TenderApplication ta)
        {
            foreach (TenderOffer to in ta.TenderOffers)
            {
                MailContent content = new MailContent()
                {
                    ToEmail = email,
                    Subject = "Hospital tender ended",
                    Body = "    Unfortunately, you did not win on our equipment tender. Detailed informations " +
                    "about tender are in the continuation of this email. Blood amount : " + to.TenderRequirement.Amount + " ." +
                    "Blood type :" + to.TenderRequirement.BloodType.ToString() + ".",
                    Attachments = null
                };
                _bloodBankService.SendEmail(content);
                break;
            }
        }
        
        public string GenerateAndUploadPdf(DateRange dateRange)
        {
            var folderPath = Environment.CurrentDirectory + "\\PDFs";
            var fileName = "TenderReport_" + DateTime.Now.Ticks + ".pdf";
            var filePath = Path.Combine(folderPath, fileName);

            GeneratePdf(_repository.GetFinishedApplications(dateRange), filePath);

            SFTPService.UploadPDF(filePath, "Tender\\" + fileName);
            return filePath;
        }

        private void GeneratePdf(ICollection<TenderApplication> data, string filePath)
        {
            var stream = new FileStream(filePath, FileMode.Create);
            DocumentBuilder builder = DocumentBuilder.New();
            var section = builder.AddSection();

            double[] nums = { 0, 0, 0, 0, 0, 0, 0, 0 };
            double totalMoney = 0;

            section.AddParagraph("Tender report");
            section.AddLine();
            section.AddParagraph(" ");

            foreach (TenderApplication ta in data)
            {
                section.AddParagraph("Tender name: " + ta.EquipmentTender.Title);
                section.AddParagraph("Blood bank: " + ta.User.AppName);
                section.AddParagraph("Tender finished on: " + ta.Finished);
                section.AddParagraph(" ");

                foreach (TenderOffer offer in ta.TenderOffers)
                {
                    string temp = "           ";
                    temp += offer.TenderRequirement.BloodType + " -> ";
                    temp += offer.TenderRequirement.Amount;
                    temp += " (" + offer.Money.Amount + " EUR)";
                    nums[(int)offer.TenderRequirement.BloodType] += offer.TenderRequirement.Amount;
                    totalMoney += offer.Money.Amount;
                    section.AddParagraph(temp);
                }
                
                section.AddParagraph(" ");
                section.AddParagraph(" ");
            }

            section.AddParagraph("Total");
            section.AddLine();
            section.AddParagraph(" ");

            for (int i = 0; i < 8; i++)
            {
                string temp = "";
                temp += (BloodType)i + " -> ";
                temp += nums[i];
                section.AddParagraph(temp);
            }

            section.AddParagraph(" ");
            section.AddParagraph("Total money: " + totalMoney + " EUR");

            builder.Build(stream);
            stream.Close();
        }
    }
}
