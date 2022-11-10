using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
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
    
    
    
    
    
    
    
    
    
    }
}
