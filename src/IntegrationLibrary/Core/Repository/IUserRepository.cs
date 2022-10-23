using IntegrationLibrary.Core.Model;
using System.Collections.Generic;

namespace IntegrationLibrary.Core.Repository
{
    public interface IUserRepository
    {
        void Register(User user);
        IEnumerable<User> GetAll();
        User GetBy(string email);
        void ChangePassword(User user, string password);
    }
}
