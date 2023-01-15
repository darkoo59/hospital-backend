using System;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Utility;
using System.Collections.Generic;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using IntegrationLibrary.Features.BloodBank.Repository;
using IntegrationLibrary.Features.BloodBank.Model;
using IntegrationLibrary.Features.BloodBank.DTO;

namespace IntegrationLibrary.Features.BloodBank.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IBloodBankService _bloodBankService;

        public UserService(IUserRepository userRepository, IBloodBankService bloodBankService)
        {
            _userRepository = userRepository;
            _bloodBankService = bloodBankService;
        }

        public async Task<bool> Register(User user)
        {
            if (_userRepository.GetAll().Any(u => u.Email.Equals(user.Email)))
            {
                throw new User.DuplicateEMailException("User with given email already exists.");
            }
            user.Password = KeyGenerator.GetUniqueKey(16);


            string key = await _bloodBankService.GenerateApiKey(user);
            _userRepository.Register(user);

            MailContent mailContent = JsonSerializer.Deserialize<MailContent>(File.ReadAllText("../IntegrationLibrary/Resources/mailTemplate.json"));

            mailContent.ToEmail = user.Email;
            mailContent.Body = mailContent.Body + user.Password + ". API_KEY: " + key;

            await _bloodBankService.SendEmail(mailContent);

            return true;
        }

        public string Login(UserLoginDTO userLogin, IConfiguration config)
        {
            var user = Authenticate(userLogin);

            if (user == null)
                return null;

            var token = Generate(user, config);

            return token;
        }

        public void ChangePassword(string email, ChangePasswordDTO dto)
        {
            User user = GetBy(email);
            if (user == null) return;
            if (!user.Password.Equals(dto.OldPassword)) throw new User.BadPasswordException("Old password is not valid");
            //TODO: password requirements validation

            _userRepository.ChangePassword(user, dto.NewPassword);
        }

        private User Authenticate(UserLoginDTO userLogin)
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
                new Claim(ClaimTypes.Email, user.Email)
            };

            var token = new JwtSecurityToken(config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(30),
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

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public string GetAppNameByServer(string server)
        {
            return _userRepository.GetAppNameByServer(server);
        }
    }
}
