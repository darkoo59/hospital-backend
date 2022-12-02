using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public interface ISymptomRepository
    {
        IEnumerable<Symptom> GetAll();
        Symptom GetById(int id);
        void Create(Symptom symptom);
        void Update(Symptom symptom);
        void Delete(Symptom symptom);
    }
}
