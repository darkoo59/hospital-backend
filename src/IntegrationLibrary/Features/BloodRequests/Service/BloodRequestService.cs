using IntegrationLibrary.Features.BloodRequests.DTO;
using IntegrationLibrary.Features.BloodRequests.Model;
using IntegrationLibrary.Features.BloodRequests.Repository;
using System;
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

        public void Create(BloodRequestDTO dto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BloodRequest> GetAll()
        {
            throw new NotImplementedException();
        }

        public BloodRequest GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
