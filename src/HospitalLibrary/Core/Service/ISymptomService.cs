using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public interface ISymptomService
    {
        IEnumerable<Symptom> GetAll();
        Symptom GetById(int id);
        void Create(Symptom symptom);
        void Update(Symptom symptom);
        void Delete(Symptom symptom);
        List<Symptom> GetAll(List<int> ids);
    }
}
