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
            return _context.InpatientTreatmentTherapies.Include(i => i.InpatientTreatment).Include(i => i.InpatientTreatment.Patient)
                .Include(i => i.InpatientTreatment.Room).Include(i => i.InpatientTreatment.Room.Beds).Include(i => i.InpatientTreatment.Bed)
                .Include(i => i.MedicineTherapies).Include(i => i.BloodTherapies).ToList();
        }

        public InpatientTreatmentTherapy GetById(int id)
        {
            return _context.InpatientTreatmentTherapies.Find(id);
        }

        public void Update(InpatientTreatmentTherapy inpatientTreatmentTherapy)
        {
            _context.Entry(inpatientTreatmentTherapy).State = EntityState.Modified;

            try
            {
                _context.Update(inpatientTreatmentTherapy);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
