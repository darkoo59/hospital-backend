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
    public class InpatientTreatmentRepository : IInpatientTreatmentRepository
    {
        private readonly HospitalDbContext _context;

        public InpatientTreatmentRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public void Create(InpatientTreatment inpatientTreatment)
        {
            _context.InpatientTreatments.Add(inpatientTreatment);
            _context.SaveChanges();
        }

        public void Delete(InpatientTreatment inpatientTreatment)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InpatientTreatment> GetAll()
        {
            return _context.InpatientTreatments.Include(i => i.Patient).Include(i => i.Room).Include(i => i.Room.Beds).Include(i => i.Bed).ToList();
        }

        public InpatientTreatment GetById(int id)
        {
            return _context.InpatientTreatments.Find(id);
        }

        public void Update(InpatientTreatment inpatientTreatment)
        {
            throw new NotImplementedException();
        }
    }
}
