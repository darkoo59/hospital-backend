using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository;
using System.Collections;
using System.Collections.Generic;

namespace IntegrationLibrary.Core.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Register(User user)
        {
            _userRepository.Register(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }
    }
}
