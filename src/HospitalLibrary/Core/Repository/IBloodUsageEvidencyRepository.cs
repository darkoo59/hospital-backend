using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public interface IBloodUsageEvidencyRepository
    {
        IEnumerable<BloodUsageEvidency> GetAll();
        BloodUsageEvidency GetById(int id);

        void Create(BloodUsageEvidency bloodUsageEvidency);
        void Update(BloodUsageEvidency bloodUsageEvidency);
        void Delete(BloodUsageEvidency bloodUsageEvidency);
    }
}
