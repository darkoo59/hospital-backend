using IntegrationLibrary.Core.Enums;
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

        public void Create(BloodRequest br)
        {
            _bloodRequestRepository.Create(br);
        }

        public IEnumerable<BloodRequest> GetAll()
        {
            return _bloodRequestRepository.GetAll();
        }

        public BloodRequest GetById(int id)
        {
            return _bloodRequestRepository.GetById(id);
        }
    }
}
