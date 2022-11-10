using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using MailKit;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{

    public class PatientService : IPatientService
    {

        private readonly IPatientRepository _patientRepository;
        private readonly IEmailSender _mailService;

        public PatientService(IPatientRepository patientRepository, IEmailSender mailService)
        {
            _patientRepository = patientRepository;
            _mailService = mailService;
        }
        
        public void Delete(Patient patient)
        {
            _patientRepository.Delete(patient);
        }

        public IEnumerable<Patient> GetAll()
        {
            return _patientRepository.GetAll();
        }

        public Patient GetById(int id)
        {
            return _patientRepository.GetById(id);
        }

        public async Task<bool> Register(Patient patient)
        {
            if (_patientRepository.GetAll().Any(u => u.Email.Equals(patient.Email)))
            {
                throw new Patient.DuplicateEMailException("User with given email already exists.");
            }
            
            _patientRepository.Register(patient);

            MailContent mailContent = JsonSerializer.Deserialize<MailContent>(File.ReadAllText("../HospitalLibrary/Resources/mailTemplate.json"));

            mailContent.ToEmail = patient.Email;
            mailContent.Body += patient.PatientId;

            await _mailService.SendEmail(mailContent);

            return true;

        }
    }
}
