using IntegrationLibrary.Features.BloodBank.Model;
using IntegrationLibrary.Settings;
using System.Collections.Generic;
using System.Linq;

namespace IntegrationLibrary.Features.BloodBank.Repository
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

        public User GetById(int id)
        {
            return GetAll().FirstOrDefault(user => user.Id == id);
        }

        public string GetAppNameByServer(string server)
        {
            return GetAll().FirstOrDefault(user => user.Server == server).AppName;
        }
    }
}
