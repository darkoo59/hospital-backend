using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Settings;
using System.Collections.Generic;
using System.Linq;

namespace IntegrationLibrary.Core.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IntegrationDbContext _context;

        public UserRepository(IntegrationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetBy(string email)
        {
            return GetAll().FirstOrDefault(user => user.Email.ToLower().Equals(email.ToLower()));
        }

        public void Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void ChangePassword(User user, string password)
        {
            user.Password = password;
            _context.SaveChanges();
        }
    }
}
