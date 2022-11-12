using IntegrationLibrary.Features.BloodRequests.Enums;
using IntegrationLibrary.Features.BloodRequests.Model;
using IntegrationLibrary.Features.BloodRequests.Repository;
using System.Collections.Generic;

namespace IntegrationLibrary.Features.BloodRequests.Service
{
    public class BloodRequestService : IBloodRequestService
    {
        private readonly IBloodRequestRepository _bloodRequestRepository;
        public BloodRequestService(IBloodRequestRepository bloodRequestRepository)
        {
            _bloodRequestRepository = bloodRequestRepository;
        }

        public void Create(BloodRequest br)
        {
            _bloodRequestRepository.Create(br);
        }

        public IEnumerable<BloodRequest> GetAll()
        {
            return _bloodRequestRepository.GetAll();
        }

        public IEnumerable<BloodRequest> GetAllByState(BloodRequestState state)
        {
            List<BloodRequest> res = new();
            foreach (BloodRequest br in GetAll())
            {
                if (br.State == state) res.Add(br);
            }
            return res;
        }

        public BloodRequest GetById(int id)
        {
            return _bloodRequestRepository.GetById(id);
        }
    }
}
