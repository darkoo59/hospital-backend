using HospitalLibrary.Core.Model;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Repository
{
    public interface IBloodRequestRepository
    {
        IEnumerable<BloodRequest> GetAll();
        BloodRequest GetById(int id);
        void Create(BloodRequest bloodRequest);
        void Update(BloodRequest bloodRequest);
        void Delete(BloodRequest bloodRequest);
    }
}
