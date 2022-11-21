using HospitalLibrary.SharedModel;

namespace HospitalLibrary.Security
{
    public interface IUserRepository
    {
        User Login(string username, string password);
        User GetById(int id);
    }
}
