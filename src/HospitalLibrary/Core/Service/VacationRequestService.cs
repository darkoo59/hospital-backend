using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class VacationRequestService : IVacationRequestService
    {
        private readonly IVacationRequestRepository _vacationRequestRepository;
        private readonly AppointmentService _appointmentService;
        private IAppointmentRepository appointmentRepository;

        public VacationRequestService(IVacationRequestRepository vacationRequestRepository)
        {
            _vacationRequestRepository = vacationRequestRepository;
        }

        public VacationRequestService(IAppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
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

    }
}
