using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Service
{
    public class VacationRequestService : IVacationRequestService
    {
        private readonly IVacationRequestRepository _vacationRequestRepository;

        public VacationRequestService(IVacationRequestRepository vacationRequestRepository)
        {
            _vacationRequestRepository = vacationRequestRepository;
        }

        public IEnumerable<VacationRequest> GetAll()
        {
            return _vacationRequestRepository.GetAll();
        }

        public VacationRequest GetById(int id)
        {
            return _vacationRequestRepository.GetById(id);
        }

        public bool IsVacationDateStartValid(VacationRequest vacationRequest)
        {
            return true;
        }
        public void Create(VacationRequest vacationRequest)
        {
            _vacationRequestRepository.Create(vacationRequest);
        }
        public void Delete(VacationRequest vacationRequest)
        {
            _vacationRequestRepository.Delete(vacationRequest);
        }
    }
}
