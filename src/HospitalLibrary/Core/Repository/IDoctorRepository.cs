using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Repository
{
    public interface IDoctorRepository
    {
        Doctor GetById(int id);
    }
}
