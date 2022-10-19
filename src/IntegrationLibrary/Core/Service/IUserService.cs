using IntegrationLibrary.Core.Model;
using System.Collections;
using System.Collections.Generic;

namespace IntegrationLibrary.Core.Service
{
    public interface IUserService
    {
        void Register(User user);
        IEnumerable<User> GetAll();
    }
}
