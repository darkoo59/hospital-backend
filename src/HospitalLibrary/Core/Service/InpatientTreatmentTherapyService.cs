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
            return _inpatientTreatmentTherapyRepository.GetAll();
        }

        public InpatientTreatmentTherapy GetById(int id)
        {
            return _inpatientTreatmentTherapyRepository.GetById(id);
        }

        public void Update(InpatientTreatmentTherapy inpatientTreatmentTherapy)
        {
                _inpatientTreatmentTherapyRepository.Update(inpatientTreatmentTherapy);
        }

        public InpatientTreatmentTherapy GetInpatientTreatmentTherapy(int id)
        {
            foreach (var inpatientTreatmentTherapy in GetAll())
            {
                if (inpatientTreatmentTherapy.InpatientTreatmentId == id)
                {
                    return inpatientTreatmentTherapy;
                }
            }
            return null;
        }
    }
}
