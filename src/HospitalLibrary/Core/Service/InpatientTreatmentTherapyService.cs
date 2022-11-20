using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class InpatientTreatmentTherapyService : IInpatientTreatmentTherapyService
    {
        private readonly IInpatientTreatmentTherapyRepository _inpatientTreatmentTherapyRepository;

        public InpatientTreatmentTherapyService(IInpatientTreatmentTherapyRepository inpatientTreatmentTherapyRepository) {
            _inpatientTreatmentTherapyRepository = inpatientTreatmentTherapyRepository;
        }

        public void Create(InpatientTreatmentTherapy inpatientTreatmentTherapy)
        {
            _inpatientTreatmentTherapyRepository.Create(inpatientTreatmentTherapy);
        }

        public void Delete(InpatientTreatmentTherapy inpatientTreatmentTherapy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InpatientTreatmentTherapy> GetAll()
        {
            throw new NotImplementedException();
        }

        public InpatientTreatmentTherapy GetById(int id)
        {
            return _inpatientTreatmentTherapyRepository.GetById(id);
        }

        public void Update(InpatientTreatmentTherapy inpatientTreatmentTherapy)
        {
            throw new NotImplementedException();
        }
    }
}
