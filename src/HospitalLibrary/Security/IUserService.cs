using HospitalLibrary.SharedModel;

namespace HospitalLibrary.Security
{
    public interface IUserService
    {
        AuthenticationToken Login(string username, string password);
        User GetById(int id);
    }
}
