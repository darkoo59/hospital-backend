using IntegrationLibrary.Features.BloodRequests.Enums;
using IntegrationLibrary.Features.BloodRequests.Model;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.BloodRequests.Service
{
    public interface IBloodRequestService
    {
        IEnumerable<BloodRequest> GetAll();
        BloodRequest GetById(int id);
        void Create(BloodRequest br);
        IEnumerable<BloodRequest> GetAllByState(BloodRequestState state);
    }
}
