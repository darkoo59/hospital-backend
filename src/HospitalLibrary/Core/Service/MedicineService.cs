using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;

namespace HospitalLibrary.Core.Service
{
    public class MedicineService : IMedicineService
    {

        private readonly IMedicineRepository _medicineRepository;

        public MedicineService(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        public Task<bool> Create(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public void Delete(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Medicine> GetAll()
        {
            return _medicineRepository.GetAll();
        }

        public Medicine GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public List<Medicine> GetAll(List<int> ids)
        {
            List<Medicine> medicines = new List<Medicine>();
            foreach (var medicine in _medicineRepository.GetAll())
            {
                if (ids.Contains(medicine.MedicineId))
                {
                    medicines.Add(medicine);
                }
            }

            return medicines;
        }
    }
}
