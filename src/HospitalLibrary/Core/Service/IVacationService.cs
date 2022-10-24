using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Service
{
    public interface IVacationService
    {
        IEnumerable<Vacation> GetAll();
        Vacation GetById(int id);
        void Create(Vacation vacation);
        void Update(Vacation vacation);
        void Delete(Vacation vacation);
    }
}
