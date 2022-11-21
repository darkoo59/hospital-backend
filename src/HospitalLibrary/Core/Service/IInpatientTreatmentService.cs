using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public interface IInpatientTreatmentService
    {
        IEnumerable<InpatientTreatment> GetAll();
        InpatientTreatment GetById(int id);
        void Create(InpatientTreatment inpatientTreatment);
        void Update(InpatientTreatment inpatientTreatment);
        void Delete(InpatientTreatment inpatientTreatment);
        InpatientTreatment GetInpatientTreatment(int patientId);
    }
}
