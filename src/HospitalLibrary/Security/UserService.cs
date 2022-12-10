using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.SharedModel;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

namespace HospitalLibrary.Security
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtGenerator _jwtGenerator;

        public UserService(IUserRepository userRepository)
        {
            _jwtGenerator = new JwtGenerator();
            _userRepository = userRepository;
        }

        public AuthenticationToken Login(string username, string password)
        {
            var user = _userRepository.Login(username, password);

            if (user == null) return null;

            return _jwtGenerator.GenerateAccessToken(user.UserId, user.Role.ToString());
        }
        public User GetById(int id) 
        {
            return _userRepository.GetById(id);
        }

        /*public User GetByEmail(string email)
        {
            return _userRepository.GetByEmail(email);
        }*/

        
    }
}
