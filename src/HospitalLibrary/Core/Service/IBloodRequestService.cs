using HospitalLibrary.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public interface IBloodRequestService
    {
        IEnumerable<BloodRequest> GetAll();
        BloodRequest GetById(int id);
        Task<bool> Create(BloodRequest bloodRequest);
        void Update(BloodRequest bloodRequest);
        void Delete(BloodRequest bloodRequest);
    }
}
