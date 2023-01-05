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
            return _context.Medicines.Find(id);
        }

        public List<Medicine> GetByIds(List<int> ids)
        {
            List<Medicine> allMedicines = GetAll().ToList();
            List<Medicine> returnMedicines = new List<Medicine>();
            
            foreach(int id in ids) 
            { 
                foreach(Medicine medicine in allMedicines)
                {
                    if(medicine.MedicineId == id)
                    {
                        returnMedicines.Add(medicine);
                    }
                }
            }
            return returnMedicines;
        }

        public void Update(Medicine medicine)
        {
            throw new NotImplementedException();
        }
    }
}
