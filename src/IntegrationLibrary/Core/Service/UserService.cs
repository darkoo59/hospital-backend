using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository;
using IntegrationLibrary.Core.Utility;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
            if (_userRepository.GetAll().Any(u => u.Email.Equals(user.Email)))
            {
                throw new User.DuplicateEMailException("User with given email already exists.");
            }
            user.Password = KeyGenerator.GetUniqueKey(16);
            _userRepository.Register(user);

            //TODO: send email with generated password
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }
    }
}
