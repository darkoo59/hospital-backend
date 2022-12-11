using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class SymptomService : ISymptomService
    {
        private readonly ISymptomRepository _symptomRepository;

        public SymptomService(ISymptomRepository symptomRepository)
        {
            _symptomRepository = symptomRepository;
        }

        public void Create(Symptom symptom)
        {
            _symptomRepository.Create(symptom);
        }

        public void Delete(Symptom symptom)
        {
            _symptomRepository.Delete(symptom);
        }

        public IEnumerable<Symptom> GetAll()
        {
            return _symptomRepository.GetAll();
        }

        public Symptom GetById(int id)
        {
            return _symptomRepository.GetById(id);
        }

        public void Update(Symptom symptom)
        {
            _symptomRepository.Update(symptom);
        }
    }
}
