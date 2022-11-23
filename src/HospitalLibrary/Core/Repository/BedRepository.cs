using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Core.Repository
{
    public class BedRepository : IBedRepository
    {

        private readonly HospitalDbContext _context;

        public BedRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public void Create(Bed bed)
        {
            throw new NotImplementedException();
        }

        public void Delete(Bed bed)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bed> GetAll()
        {
            return _context.Beds.ToList();
        }

        public Bed GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Bed bed)
        {
            _context.Entry(bed).State = EntityState.Modified;

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
