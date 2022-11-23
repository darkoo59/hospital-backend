using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;

namespace HospitalLibrary.Core.Repository
{
    public class MedicineRepository : IMedicineRepository
    {

        private readonly HospitalDbContext _context;

        public MedicineRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public void Create(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public void Delete(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Medicine> GetAll()
        {
            return _context.Medicines.ToList();
        }

        public Medicine GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Medicine medicine)
        {
            throw new NotImplementedException();
        }
    }
}
