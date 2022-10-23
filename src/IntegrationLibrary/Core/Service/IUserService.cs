using IntegrationLibrary.Core.Model;
using IntegrationLibrary.DTO;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace IntegrationLibrary.Core.Service
{
    public interface IUserService
    {
        void Register(User user);
        string Login(UserLogin userLogin, IConfiguration config);
        IEnumerable<User> GetAll();
        User GetBy(string email);
        void ChangePassword(string email, ChangePasswordDTO dto);
    }
}
