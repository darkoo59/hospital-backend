using IntegrationLibrary.Features.BloodRequests.Model;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.BloodRequests.Repository
{
    public interface IBloodRequestRepository
    {
        IEnumerable<BloodRequest> GetAll();
        void Create(BloodRequest bloodRequest);
    }
}
