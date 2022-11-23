using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class InpatientTreatmentService : IInpatientTreatmentService
    {
        private readonly IInpatientTreatmentRepository _inpatientTreatmentRepository;

        public InpatientTreatmentService(IInpatientTreatmentRepository inpatientTreatmentRepository)
        {
            _inpatientTreatmentRepository = inpatientTreatmentRepository;
        }

        public void Create(InpatientTreatment inpatientTreatment)
        {
            _inpatientTreatmentRepository.Create(inpatientTreatment);
        }

        public void Delete(InpatientTreatment inpatientTreatment)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InpatientTreatment> GetAll()
        {
            return _inpatientTreatmentRepository.GetAll();
        }

        public InpatientTreatment GetById(int id)
        {
            return _inpatientTreatmentRepository.GetById(id);
        }

        public void Update(InpatientTreatment inpatientTreatment)
        {
            throw new NotImplementedException();
        }

        public InpatientTreatment GetInpatientTreatment(int patientId)
        {
            foreach (var inpatientTreatment in GetAll())
            {
                if (inpatientTreatment.PatientId == patientId)
                {
                    return inpatientTreatment;
                }
            }
            return null;
        }
    }
}
