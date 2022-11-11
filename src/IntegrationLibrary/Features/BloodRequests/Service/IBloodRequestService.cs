using IntegrationLibrary.Features.BloodRequests.Model;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.BloodRequests.Service
{
    public interface IBloodRequestService
    {
        IEnumerable<BloodRequest> GetAll();
        void Create(BloodRequest bloodRequest);
    }
}
