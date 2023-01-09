using IntegrationLibrary.Features.BloodBank.DTO;
using IntegrationLibrary.Features.BloodBank.Model;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntegrationLibrary.Features.BloodBank.Service
{
    public interface IUserService
    {
        Task<bool> Register(User user);
        string Login(UserLoginDTO userLogin, IConfiguration config);
        IEnumerable<User> GetAll();
        User GetBy(string email);
        void ChangePassword(string email, ChangePasswordDTO dto);
        User GetById(int id);
        string GetAppNameByServer(string server);
    }
}
