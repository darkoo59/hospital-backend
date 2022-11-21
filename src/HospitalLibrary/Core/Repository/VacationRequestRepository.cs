using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public class VacationRequestRepository : IVacationRequestRepository
    {
        private readonly HospitalDbContext _context;

        public VacationRequestRepository(HospitalDbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<VacationRequest> GetAll()
        {
            
            return _context.VacationRequests.ToList();
        }

        public VacationRequest GetById(int id)
        {
            return _context.VacationRequests.Find(id);
        }

        public void Create(VacationRequest vacationRequest)
        {
            _context.VacationRequests.Add(vacationRequest);
            _context.SaveChanges();
        }

        public void Delete(VacationRequest vacationRequest)
        {
            _context.VacationRequests.Remove(vacationRequest);
            _context.SaveChanges();
        }
        public void  approveVacationRequest(int vacationRequestId)
        {
            foreach (VacationRequest vacationRequest in _context.VacationRequests)
            {
                if (vacationRequest.VacationRequestId == vacationRequestId)
                {
                    vacationRequest.Status = Enums.VacationRequestStatus.Approved;
                    _context.Update(vacationRequest);

                }
            
            }
            _context.SaveChanges();
 
        }
        public void NotapproveVacationRequest(int vacationRequestId)
        {
            foreach (VacationRequest vacationRequest in _context.VacationRequests)
            {
                if (vacationRequest.VacationRequestId == vacationRequestId)
                {
              
                    vacationRequest.Status = Enums.VacationRequestStatus.NotApproved;
                    _context.Update(vacationRequest);

                }

            }
            _context.SaveChanges();

        }

    }
}
