using IntegrationLibrary.Features.BloodBank.Model;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.BloodBank.Repository
{
    public interface IUserRepository
    {
        void Register(User user);
        IEnumerable<User> GetAll();
        User GetBy(string email);
        void ChangePassword(User user, string password);
        User GetById(int id);

        string GetAppNameByServer(string server);
    }
}
