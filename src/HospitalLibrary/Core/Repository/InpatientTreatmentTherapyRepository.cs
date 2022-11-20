using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public class InpatientTreatmentTherapyRepository : IInpatientTreatmentTherapyRepository
    {
        private readonly HospitalDbContext _context;

        public InpatientTreatmentTherapyRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public void Create(InpatientTreatmentTherapy inpatientTreatmentTherapy)
        {
            _context.InpatientTreatmentTherapies.Add(inpatientTreatmentTherapy);
            _context.SaveChanges();
        }

        public void Delete(InpatientTreatmentTherapy inpatientTreatmentTherapy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InpatientTreatmentTherapy> GetAll()
        {
            throw new NotImplementedException();
        }

        public InpatientTreatmentTherapy GetById(int id)
        {
            return _context.InpatientTreatmentTherapies.Find(id);
        }

        public void Update(InpatientTreatmentTherapy inpatientTreatmentTherapy)
        {
            throw new NotImplementedException();
        }
    }
}
