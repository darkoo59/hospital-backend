using HospitalLibrary.SharedModel;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Security
{
    public class UserRepository : IUserRepository
    {
        private readonly HospitalDbContext _context;

        public UserRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }
        public User Login(string username, string password)
        {
            foreach (User user in GetAll()) 
            {
                if (user.Username.Equals(username)&&user.Password.Equals(password)) 
                {
                    return user;
                }
            }
            return null;
        }
        public User GetById(int id) 
        {
            foreach (User user in GetAll())
            {
                if (user.UserId == id)
                {
                    return user;
                }
            }
            return null;
        }
    }
}
