using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository;
using IntegrationLibrary.Core.Utility;
using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IntegrationLibrary.Core.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMailService _mailService;

        public UserService(IUserRepository userRepository, IMailService mailService)
        {
            _userRepository = userRepository;
            _mailService = mailService;
        }

        public async void Register(User user)
        {
            if (_userRepository.GetAll().Any(u => u.Email.Equals(user.Email)))
            {
                throw new User.DuplicateEMailException("User with given email already exists.");
            }
            user.Password = KeyGenerator.GetUniqueKey(16);
            _userRepository.Register(user);

            //TODO: send email with generated password
            MailContent mailContent = new MailContent();
            mailContent.Subject = "Welcome";
            mailContent.ToEmail = "darkoo59@gmail.com";
            mailContent.Attachments = null;
            mailContent.Body = "Ulogujte se na sledecem linku i nakon toga obavezno promenite sifru!" +
                "Link : localhost:4200/integration/login";
            try
            {
                await _mailService.SendEmail(mailContent);
                return;
            }catch(Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }
    }
}
