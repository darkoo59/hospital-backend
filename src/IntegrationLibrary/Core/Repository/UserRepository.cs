using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Settings;
using System.Collections.Generic;
using System.Linq;
using static IntegrationLibrary.Core.Model.User;

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

        public void Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
