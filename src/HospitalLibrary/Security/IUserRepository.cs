using HospitalLibrary.Core.Model;
using HospitalLibrary.SharedModel;
using System.Collections.Generic;

namespace HospitalLibrary.Security
{
    public interface IUserRepository
    {
        User Login(string username, string password);
        User GetById(int id);
        User GetByEmail(string email);
        IEnumerable<User> GetAll();
        void Register(User user);
        void Update(User user);
        void Delete(User user);
    }
}
