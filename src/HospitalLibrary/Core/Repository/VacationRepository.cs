using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;

namespace HospitalLibrary.Core.Repository
{
    public class VacationRepository : IVacationRepository
    {

        private readonly HospitalDbContext _context;

        public VacationRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public void Create(Vacation vacation)
        {
            throw new NotImplementedException();
        }

        public void Delete(Vacation vacation)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vacation> GetAll()
        {
            return _context.Vacations.ToList();
        }

        public Vacation GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Vacation vacation)
        {
            throw new NotImplementedException();
        }
    }
}
