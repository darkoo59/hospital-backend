using System;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository;
using IntegrationLibrary.Core.Utility;
using Org.BouncyCastle.Asn1.Cms;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;

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

            
            MailContent mailContent = new MailContent();
            mailContent.Subject = "Welcome";
            mailContent.ToEmail = user.Email;
            mailContent.Attachments = null;
            mailContent.Body = "Ulogujte se na sledecem linku i nakon toga obavezno promenite sifru! " +
                "Link : localhost:4200/integration/login" + " . Vasa generisana sifra za prvo logovanje : " + user.Password;
            try
            {
                await _mailService.SendEmail(mailContent);
                return;
            }catch(Exception ex)
            {
                throw;
            }
        }

        public string Login(UserLogin userLogin, IConfiguration config)
        {
            var user = Authenticate(userLogin);

            if (user == null)
                return null;
            
            var token = Generate(user, config);

            return token;
        }
        private User Authenticate(UserLogin userLogin)
        {
            var currentUser = GetBy(userLogin.Email);

            if (currentUser == null)
                return null;

            return currentUser.Password.Equals(userLogin.Password) ? currentUser : null;
        }

        private string Generate(User user, IConfiguration config)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            var claims = new[]
            {
                new Claim("email", user.Email)
            };

            var token = new JwtSecurityToken(config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetBy(string email)
        {
            return _userRepository.GetBy(email);
        }
    }
}
