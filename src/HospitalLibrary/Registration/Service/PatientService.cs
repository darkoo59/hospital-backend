using HospitalLibrary.Core.Model;
using HospitalLibrary.Registration.Model;
using HospitalLibrary.Registration.Repository;
using HospitalLibrary.Security;
using HospitalLibrary.SharedModel;
using MailKit;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace HospitalLibrary.Registration.Service
{

    public class PatientService : IPatientService
    {


        private readonly IMedicalRecordRepository _medicalRecordRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEmailSender _mailService;

        public PatientService(IPatientRepository patientRepository, IMedicalRecordRepository medicalRecordRepository, IUserRepository userRepository, IEmailSender mailService)
        {
            _patientRepository = patientRepository;
            _mailService = mailService;
            _medicalRecordRepository = medicalRecordRepository;
            _userRepository = userRepository;
        }

        public void Delete(Patient patient)
        {
            _patientRepository.Delete(patient);
        }

        public void ActivateAccount(Patient patient)
        {
            patient.IsAccountActivated = true;
            _patientRepository.Update(patient);
        }

        public IEnumerable<Patient> GetAll()
        {
            return _patientRepository.GetAll();
        }

        public Patient GetById(int id)
        {
            return _patientRepository.GetById(id);
        }

        public async Task<bool> Register(User user, Patient patient, MedicalRecord medicalRecord)
        {
            if (_userRepository.GetAll().Any(u => u.Email.Equals(user.Email)))
            {
                throw new User.DuplicateEMailException("User with given email already exists.");
            }

            //TODO: logika za registraciju

            _medicalRecordRepository.Register(medicalRecord);

            _userRepository.Register(user);

            //User u = _userRepository.GetByEmail(user.Email);

            patient.UserId = user.UserId;

            _patientRepository.Register(patient);

            MailContent mailContent = JsonSerializer.Deserialize<MailContent>(File.ReadAllText("../HospitalLibrary/Resources/mailTemplate.json"));

            mailContent.ToEmail = user.Email;
            mailContent.Body += patient.PatientId;

            await _mailService.SendEmail(mailContent);

            return true;

        }
    }
}
