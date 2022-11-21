using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public interface IVacationRequestService
    {
        IEnumerable<VacationRequest> GetAll();
        public VacationRequest GetById(int id);
        public bool IsVacationDateStartValid(VacationRequest vacationRequest);
        public void Create(VacationRequest vacationRequest);
        public void Delete(VacationRequest vacationRequest);
        public List<VacationRequest> GetDoctorVacationRequests(int doctorId);
        public bool IsValidationRequestValid(VacationRequest vacationRequest);
        void CreateUrgentVacation(int doctorId, DateTime start, DateTime end, VacationRequest vacationRequest);
        public void approveVacationRequest(int vacationRequestId);
        public void NotapproveVacationRequest(int vacationRequestId);
    }
}
