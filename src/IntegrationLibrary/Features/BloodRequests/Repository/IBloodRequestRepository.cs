using IntegrationLibrary.Features.BloodRequests.Model;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.BloodRequests.Repository
{
    public interface IBloodRequestRepository
    {
        IEnumerable<BloodRequest> GetAll();
        BloodRequest GetById(int id);
        void Create(BloodRequest bloodRequest);
        void Update(BloodRequest bloodRequest);
    }
}
