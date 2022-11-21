using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public interface IInpatientTreatmentTherapyService
    {
        IEnumerable<InpatientTreatmentTherapy> GetAll();
        InpatientTreatmentTherapy GetById(int id);
        void Create(InpatientTreatmentTherapy inpatientTreatmentTherapy);
        void Update(InpatientTreatmentTherapy inpatientTreatmentTherapy);
        void Delete(InpatientTreatmentTherapy inpatientTreatmentTherapy);
        InpatientTreatmentTherapy GetInpatientTreatmentTherapy(int id);
    }
}
