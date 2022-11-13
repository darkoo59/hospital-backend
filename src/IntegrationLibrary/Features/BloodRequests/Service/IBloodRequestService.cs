using IntegrationLibrary.Features.BloodRequests.DTO;
using IntegrationLibrary.Features.BloodRequests.Enums;
using IntegrationLibrary.Features.BloodRequests.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntegrationLibrary.Features.BloodRequests.Service
{
    public interface IBloodRequestService
    {
        IEnumerable<BloodRequest> GetAll();
        BloodRequest GetById(int id);
        void Create(CreateBloodRequestDTO dto);
        Task<IEnumerable<BloodRequestDTO>> GetAllByState(BloodRequestState state);
    }
}
