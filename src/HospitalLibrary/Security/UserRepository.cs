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
                if (user.Email.Equals(username)&&user.Password.Equals(password)) 
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

        public void Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public User GetByEmail(string email)
        {
            //return _context.Users.Find(email);


            foreach (User user in GetAll())
            {
                if (user.Email.Equals(email))
                {
                    return user;
                }
            }
            return null;

        }
    }
}
