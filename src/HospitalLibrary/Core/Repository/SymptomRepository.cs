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
    public class SymptomRepository : ISymptomRepository
    {
        private readonly HospitalDbContext _context;

        public SymptomRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public void Create(Symptom symptom)
        {
            _context.Symptoms.Add(symptom);
            _context.SaveChanges();
        }

        public void Delete(Symptom symptom)
        {
            _context.Symptoms.Remove(symptom);
            _context.SaveChanges();
        }

        public IEnumerable<Symptom> GetAll()
        {
            return _context.Symptoms.ToList();
        }

        public Symptom GetById(int id)
        {
            return _context.Symptoms.Find(id);
        }

        public void Update(Symptom symptom)
        {
            _context.Entry(symptom).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
