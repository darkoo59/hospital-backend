using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public class SpecializationRepository : ISpecializationRepository
    {
        private readonly HospitalDbContext _context;

        public SpecializationRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Specialization> GetAll()
        {
            return _context.Specializations.ToList();
        }

    }
}
