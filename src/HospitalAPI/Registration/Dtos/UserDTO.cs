using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Registration.Dtos
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserDTO(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
