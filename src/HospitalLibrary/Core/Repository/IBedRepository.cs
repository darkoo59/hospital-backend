using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Repository
{
    public interface IBedRepository
    {
        IEnumerable<Bed> GetAll();
        Bed GetById(int id);
        void Create(Bed bed);
        void Update(Bed bed);
        void Delete(Bed bed);
    }
}
