using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Service
{
    public interface IMedicineService
    {
        IEnumerable<Medicine> GetAll();
        Medicine GetById(int id);
        Task<bool> Create(Medicine medicine);
        void Update(Medicine medicine);
        void Delete(Medicine medicine);
        List<Medicine> GetAll(List<int> ids);
    }
}
