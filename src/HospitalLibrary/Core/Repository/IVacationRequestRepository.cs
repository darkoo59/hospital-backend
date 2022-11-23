using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public interface IVacationRequestRepository
    {
        IEnumerable<VacationRequest> GetAll();
        public VacationRequest GetById(int id);
        public void Create(VacationRequest vacationRequest);
        public void Delete(VacationRequest vacationRequest);
        public void approveVacationRequest(int vacationRequestId);
        public void NotapproveVacationRequest(int vacationRequestId);
    }
}
