using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Repository
{
    public interface IMedicineRepository
    {
        IEnumerable<Medicine> GetAll();
        Medicine GetById(int id);
        void Create(Medicine medicine);
        void Update(Medicine medicine);
        void Delete(Medicine medicine);
    }
}
