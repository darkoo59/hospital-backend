using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Service
{
    public interface IBedService
    {
        IEnumerable<Bed> GetAll();
        Bed GetById(int id);
        Task<bool> Create(Bed bed);
        void Update(Bed bed);
        void Delete(Bed bed);
        void SetIsNotAvailable(int bedId);
    }
}
