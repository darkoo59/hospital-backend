using IntegrationLibrary.Core.Model;
using IntegrationLibrary.DTO;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service
{
    public interface IUserService
    {
        Task<bool> Register(User user);
        string Login(UserLoginDTO userLogin, IConfiguration config);
        IEnumerable<User> GetAll();
        User GetBy(string email);
        void ChangePassword(string email, ChangePasswordDTO dto);
    }
}
