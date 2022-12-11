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
    public class BloodRepository : IBloodRepository
    {
        private readonly HospitalDbContext _context;

        public BloodRepository(HospitalDbContext context)
        {
            _context = context;
        }


        public void Create(Blood blood)
        {
            _context.Bloods.Add(blood);
            _context.SaveChanges();
        }

        public void Delete(Blood blood)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Blood> GetAll()
        {
            return _context.Bloods.ToList();
        }

        public Blood GetByBloodType(BloodType bloodType)
        {
            return _context.Bloods.FirstOrDefault(b => b.BloodType == bloodType);
            
        }

        public Blood GetById(int id)
        {
            return _context.Bloods.Find(id);
        }

        public void Update(Blood blood)
        {

            _context.Entry(blood).State = EntityState.Modified; 
            try
             {
                 _context.Update(blood);
                 _context.SaveChanges();
             }
             catch (DbUpdateConcurrencyException)
             {
                 throw;
             }
         
        }



    }
}
